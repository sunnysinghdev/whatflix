
namespace WhatFlix.Infrastucture
{
    enum LogType
    {
        INFO,
        ERROR,
        WARNING,
        DEBUG,
        TRACE

    }
    interface ILogger
    {
        void Log(string message);
        void Log(LogType type, string message);
    }
}