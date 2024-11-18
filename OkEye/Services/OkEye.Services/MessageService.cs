using OkEye.Services.Interfaces;

namespace OkEye.Services
{
    /// <summary>
    /// 消息服务
    /// </summary>
    public class MessageService : IMessageService
    {
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
