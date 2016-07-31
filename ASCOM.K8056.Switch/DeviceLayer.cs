// This file is part of the TA.VellemanK8056 project
// 
// Copyright © 2015-2016 Tigra Networks., all rights reserved.
// 
// File: DeviceLayer.cs  Last modified: 2016-07-31@03:36 by Tim Long

using System;
using ASCOM.K8056.Properties;
using NLog;
using TA.Ascom.ReactiveCommunications;

namespace ASCOM.K8056
    {
    internal class DeviceLayer : IDisposable
        {
        private ITransactionProcessor transactionProcessor;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeviceLayer" /> class with a default serial port instance.
        /// </summary>
        /// <param name="channel">The communications channel, which should be closed.</param>
        internal DeviceLayer(ICommunicationChannel channel)
            {
            this.channel = channel;
            Log.Info("Creating DeviceLayer with endpoint {0}", channel.Endpoint);
            }

        /// <summary>
        ///     Opens the transaction pipeline for sending and receiving and performs initial state synchronization with the drive
        ///     system.
        /// </summary>
        public void Open()
            {
            var reactiveProcessor = new ReactiveTransactionProcessor();
            var observer = new TransactionObserver(channel);
            Open(reactiveProcessor, observer);
            var gap = TimeSpan.FromMilliseconds(Settings.Default.MinimumMillisecondsBetweenTransactions);
            reactiveProcessor.SubscribeTransactionObserver(transactionObserver, gap);
            channel.Open();
            }

        /// <summary>
        ///     Opens the transaction pipeline for sending and receiving. This overload is for unit testing and allows the
        ///     <see cref="ITransactionProcessor" /> to be injected.
        /// </summary>
        /// <param name="processor">A (possibly fake) <see cref="ITransactionProcessor" />.</param>
        /// <param name="observer">A configured <see cref="TransactionObserver" /> instance.</param>
        /// <remarks>
        ///     NOTE: No relationship is established between <paramref name="processor" /> and <paramref name="observer" />
        ///     here. If any relationship is required, it must be established prior to passing the instances in.
        /// </remarks>
        internal void Open(ITransactionProcessor processor, TransactionObserver observer)
            {
            transactionObserver = observer ?? new TransactionObserver(channel);
            transactionProcessor = processor;
            }


        public void PerformOnConnectTasks()
            {
            //ToDo: perform any tasks that must occur as soon as the communication channel is connected.
            }

        /// <summary>
        ///     Close the connection to the AWR system.
        ///     This should never fail.
        /// </summary>
        public void Close()
            {
            Log.Info($"Closing conection with {channel.Endpoint}");
            try
                {
                channel.Close();
                if (transactionObserver != null)
                    {
                    transactionObserver.OnCompleted();
                    transactionObserver = null;
                    }
                transactionProcessor = null;
                }
            catch (Exception ex)
                {
                Log.Error(ex, "Error when closing the transaction pipeline");
                }
            }

        public void SetRelay(ushort id)
            {
            var transaction = new EnergizeRelayTransaction(id);
            transactionProcessor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            }

        public void ClearRelay(ushort id)
            {
            var transaction = new ReleaseRelayTransaction(id);
            transactionProcessor.CommitTransaction(transaction);
            transaction.WaitForCompletionOrTimeout();
            }

        #region IDisposable Pattern
        // The IDisposable pattern, as described at
        // http://www.codeproject.com/Articles/15360/Implementing-IDisposable-and-the-Dispose-Pattern-P


        /// <summary>
        ///     Finalizes this instance (called prior to garbage collection by the CLR)
        /// </summary>
        ~DeviceLayer()
            {
            Dispose(false);
            }

        public bool IsOnline => transactionObserver != null && transactionObserver.ReceiverReady;

        public void Dispose()
            {
            Dispose(true);
            GC.SuppressFinalize(this);
            }

        private bool disposed;
        private readonly ICommunicationChannel channel;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private TransactionObserver transactionObserver;

        protected virtual void Dispose(bool fromUserCode)
            {
            if (!disposed)
                {
                if (fromUserCode)
                    {
                    Close();
                    }

                // ToDo - Release unmanaged resources here, if necessary.
                }
            disposed = true;

            // ToDo: Call the base class's Dispose(Boolean) method, if available.
            // base.Dispose(fromUserCode);
            }
        #endregion
        }
    }