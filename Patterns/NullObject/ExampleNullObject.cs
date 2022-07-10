﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.NullObject
{
    public class Example
    {
        public interface ILog
        {
            string Info(string msg);
            string Warn(string msg);
        }

        class ConsoleLog : ILog
        {
            public string Info(string msg) => msg;

            public string Warn(string msg) => msg;
        }

        class OptionalLog : ILog
        {
            private ILog impl;

            public OptionalLog(ILog impl)
            {
                this.impl = impl;
            }

            public string Info(string msg)
            {
                return impl?.Info(msg);
            }

            public string Warn(string msg)
            {
                return impl?.Warn(msg);
            }
        }

        public class BankAccount
        {
            private ILog log;
            private int balance;

            public BankAccount(ILog log)
            {
                this.log = new OptionalLog(log);
            }

            public void Deposit(int amount)
            {
                balance += amount;
                // check for null everywhere
                log?.Info($"Deposited ${amount}, balance is now {balance}");
            }

            public void Withdraw(int amount)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    log?.Info($"Withdrew ${amount}, we have ${balance} left");
                }
                else
                {
                    log?.Warn($"Could not withdraw ${amount} because " +
                              $"balance is only ${balance}");
                }
            }
        }

        public sealed class NullLog : ILog
        {
            public string Info(string msg) => msg;
            public string Warn(string msg) => msg;
        }
    }
}
