using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace Gss.Entities
{
    /// <summary>
    /// 连接配置数据
    /// </summary>
    public class ConnectConfigData
    {
        /// <summary>
        /// 添加编辑新闻地址
        /// </summary>
        public static string NewsAddOrEdit
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.NewsAddOrEdit_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.NewsAddOrEdit_ImitateConnectType;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.NewsAddOrEdit_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_MT.NewsAddOrEdit_ImitateConnectType;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.NewsAddOrEdit_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.NewsAddOrEdit_ImitateConnectType;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.NewsAddOrEdit_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.NewsAddOrEdit_ImitateConnectType;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.NewsAddOrEdit_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_XS.NewsAddOrEdit_ImitateConnectType;
                        }
                        break;
                }
                return null;
            }
            //get { return AppCommonConfig.NewsAddOrEdit_ImitateConnectType; }
        }
        /// <summary>
        /// 查看新闻Web地址
        /// </summary>
        public static string NewsShow
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.NewsShow_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.NewsShow_ImitateConnectType;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.NewsShow_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_MT.NewsShow_ImitateConnectType;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.NewsShow_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.NewsShow_ImitateConnectType;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.NewsShow_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.NewsShow_ImitateConnectType;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.NewsShow_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_XS.NewsShow_ImitateConnectType;
                        }
                        break;
                }
                return null;
            }
            //get { return AppCommonConfig.NewsShow_ImitateConnectType; }
        }
        /// <summary>
        /// 金生金WebService地址
        /// </summary>
        public static string JgjWebService
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.JgjWebService;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.JgjWebService;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.JgjWebService;
                        }
                        else
                        {
                            return AppCommonConfig_MT.JgjWebService;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.JgjWebService;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.JgjWebService;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.JgjWebService;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.JgjWebService;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.JgjWebService;
                        }
                        else
                        {
                            return AppCommonConfig_XS.JgjWebService;
                        }
                        break;
                }
                return null;
            }
        }
        /// <summary>
        /// 交易服务地址
        /// </summary>
        public static string TradeServiceAddress
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.TradeService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.TradeService_ImitateConnectType;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.TradeService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_MT.TradeService_ImitateConnectType;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.TradeService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.TradeService_ImitateConnectType;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.TradeService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.TradeService_ImitateConnectType;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.TradeService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_XS.TradeService_ImitateConnectType;
                        }
                        break;
                }
                return null;
            }
        }

        /// <summary>
        /// 管理服务
        /// </summary>
        public static string GssManagerAddress
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.GssManager_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.GssManager_ImitateConnectType;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.GssManager_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_MT.GssManager_ImitateConnectType;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.GssManager_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.GssManager_ImitateConnectType;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.GssManager_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.GssManager_ImitateConnectType;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.GssManager_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_XS.GssManager_ImitateConnectType;
                        }
                        break;
                }
                return null;
            }
        }

        /// <summary>
        /// 创建微会员二维码地址
        /// </summary>
        public static string OrgTicketService
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.OrgTicketService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.OrgTicketService_ImitateConnectType;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.OrgTicketService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_MT.OrgTicketService_ImitateConnectType;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.OrgTicketService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.OrgTicketService_ImitateConnectType;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.OrgTicketService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.OrgTicketService_ImitateConnectType;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.OrgTicketService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_XS.OrgTicketService_ImitateConnectType;
                        }
                        break;
                }
                return null;
            }
        }

        /// <summary>
        /// 应用程序是否显示异常信息，true显示，False不显示
        /// </summary>
        public static bool ShowException
        {
            get { return bool.Parse(AppCommonConfig.ShowException); }
        }

        /// <summary>
        /// 保证金服务地址
        /// </summary>
        public static string BzjServiceAddress
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.BzjService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.BzjService_ImitateConnectType;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.BzjService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_MT.BzjService_ImitateConnectType;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.BzjService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.BzjService_ImitateConnectType;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.BzjService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.BzjService_ImitateConnectType;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.BzjService_StockConnectType;
                        }
                        else
                        {
                            return AppCommonConfig_XS.BzjService_ImitateConnectType;
                        }
                        break;
                }
                return null;
            }
        }

        public static string srvUpdateAddr
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.srvUpdateAddr;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.srvUpdateAddr;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.srvUpdateAddr;
                        }
                        else
                        {
                            return AppCommonConfig_MT.srvUpdateAddr;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.srvUpdateAddr;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.srvUpdateAddr;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.srvUpdateAddr;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.srvUpdateAddr;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.srvUpdateAddr;
                        }
                        else
                        {
                            return AppCommonConfig_XS.srvUpdateAddr;
                        }
                        break;
                }
                return null;
            }
        }

        public static string srvUptFileVersion
        {
            get
            {
                switch (AppCommonConfig.AppCompileType)
                {
                    case "JTW":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_JTW.srvUptFileVersion;
                        }
                        else
                        {
                            return AppCommonConfig_JTW.srvUptFileVersion;
                        }
                        break;
                    case "MT":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_MT.srvUptFileVersion;
                        }
                        else
                        {
                            return AppCommonConfig_MT.srvUptFileVersion;
                        }
                        break;
                    case "ZD":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_ZD.srvUptFileVersion;
                        }
                        else
                        {
                            return AppCommonConfig_ZD.srvUptFileVersion;
                        }
                        break;
                    case "HFB":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_HFB.srvUptFileVersion;
                        }
                        else
                        {
                            return AppCommonConfig_HFB.srvUptFileVersion;
                        }
                        break;
                    case "XS":
                        if (ServceConnectType.ConnectType == ConnectType.StockServiec)
                        {
                            return AppCommonConfig_XS.srvUptFileVersion;
                        }
                        else
                        {
                            return AppCommonConfig_XS.srvUptFileVersion;
                        }
                        break;
                }
                return null;
            }
        }
    }
}
