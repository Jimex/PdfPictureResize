using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Web;
using System.Security.Cryptography;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Layouts;

namespace PdfPictureResize.Core
{
    public class AppLogger
    {
        public static bool WriteJobInfo = false;
        public static bool WriteJobDebug = false;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Log error with keyword
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="message">Log Message</param>
        /// <param name="ex">Exception, if this parameter present, that means this log is error</param>
        /// <param name="keyword">key word</param>
        /// <remarks></remarks>
        public static void LogError(string logger, object message, Exception ex, string keyword)
        {
            //Logger log = LogManager.GetLogger("ExternalDispatchingFailure");
            //log.ErrorException(message.IfNullTrim(), ex);
            Logger log = LogManager.GetLogger(logger);
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Error, logger, message.IfNullTrim());
            theEvent.Exception = ex;
            theEvent.Properties["EvtKeyword"] = keyword;
            log.Log(theEvent);
        }

        /// <summary>
        /// Log Info with keyword
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="message">Log Message</param>
        /// <param name="ex">Exception, if this parameter present, that means this log is error</param>
        /// <param name="keyword">key word</param>
        /// <remarks></remarks>
        public static void LogInfo(string logger, object message, string keyword)
        {
            //Logger log = LogManager.GetLogger("ExternalDispatchingFailure");
            //log.ErrorException(message.IfNullTrim(), ex);
            Logger log = LogManager.GetLogger(logger);
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Info, logger, message.IfNullTrim());
            theEvent.Properties["EvtKeyword"] = keyword;
            log.Log(theEvent);
        }


        public static void LogLogin(long userId, string userName, string message = "")
        {
            //Logger log = LogManager.GetLogger("ExternalDispatchingFailure");
            //log.ErrorException(message.IfNullTrim(), ex);
            Logger log = LogManager.GetLogger("LoginLog");
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Info, "LoginLog", message.IfNullTrim());
            theEvent.Properties["EvtUserName"] = userName;
            theEvent.Properties["EvtUserId"] = userId;
            log.Log(theEvent);
        }


        /// <summary>
        /// Log debug with keyword
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="message">Log Message</param>
        /// <param name="ex">Exception, if this parameter present, that means this log is error</param>
        /// <param name="keyword">key word</param>
        /// <remarks></remarks>
        public static void LogDebug(string logger, object message, string keyword)
        {
            //Logger log = LogManager.GetLogger("ExternalDispatchingFailure");
            //log.ErrorException(message.IfNullTrim(), ex);
            Logger log = LogManager.GetLogger(logger);
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Info, logger, message.IfNullTrim());
            theEvent.Properties["EvtKeyword"] = keyword;
            log.Log(theEvent);
        }

        /// <summary>
        /// Write Log through Log4Net Component
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <remarks></remarks>
        public static void LogInfo(object message)
        {
            //var log = LogManager.GetLogger("Info");
            //log.Info(message);
            LogInfo(message, String.Empty);
        }

        public static void LogInfo(object message, string keyword)
        {
            //var log = LogManager.GetLogger("Info");
            //log.Info(message);
            LogInfo("Info", message, keyword);
        }

        public static void LogJobInfo(object message, string keyword = "")
        {
            if (WriteJobInfo)
                LogInfo("JobInfo", message, keyword);
        }

        public static void LogJobDebug(object message, string keyword = "")
        {
            if (WriteJobDebug)
                LogDebug("JobDebug", message, keyword);
        }

        /// <summary>
        /// Write Log through Log4Net Component
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <remarks></remarks>
        public static void LogAudit(object message)
        {
            //var log = LogManager.GetLogger("Info");
            //log.Info(message);
            LogAudit(message, String.Empty);
        }

        public static void LogAudit(object message, string keyword)
        {
            //var log = LogManager.GetLogger("Info");
            //log.Info(message);
            LogInfo("Audit", message, keyword);
        }
        
        public static void LogError(object message, Exception ex, string keyword ="")
        {
            LogError("Error", message, ex, keyword);
        }

        public static void LogError(object message, string errorMessage, string keyword = "")
        {
            LogError("Error", message, new Exception(errorMessage), keyword);
        }
        /// <summary>
        /// Log send mail exception with keyword
        /// </summary>
        /// <param name="message">Log Message</param>
        /// <param name="ex">Exception, if this parameter present, that means this log is error</param>
        /// <param name="keyword">key word</param>
        /// <remarks></remarks>
        public static void LogSendMailException(object message, Exception ex, string keyword)
        {
            LogError("SendMailException", message, ex, keyword);
        }

        public static void LogClientInfo(object message)
        {
            //var log = LogManager.GetLogger("Info");
            //log.Info(message);
            LogInfo("ClientInfo", message, String.Empty);
        }

        public static void LogClientError(object message)
        {
            //var log = LogManager.GetLogger("Info");
            //log.Info(message);
            LogInfo("ClientError", message, String.Empty);
        }


        public static void LogFtpInfo(object message, string keyword = "")
        {
            LogInfo("FtpInfo", message, keyword);
        }


        public static void LogFtpError(object message, Exception ex, string keyword = "")
        {
            LogError("FtpError", message, ex, keyword);
        }


        public static void LogAuthenticationError(object message, Exception ex, string userId = "")
        {
            LogError("Authentication", message, ex, userId);
        }

        #region db log

        public static void LogDbInfo(object message, string keyword = "")
        {
            LogInfo("DbInfo", message, "");
        }

        public static void LogDbError(object message, Exception ex, string keyword = "")
        {
            LogError("DbError", message, ex, keyword);
        }

        public static void LogEPostInfo(object message)
        {
            LogInfo("Info", message, "");
        }

        public static void LogEPostError(object message, Exception ex, string keyword = "")
        {
            LogError("Error", message, ex, keyword);
        }
        #endregion
    }
}
