namespace Com.Cos.Application.DTO
{
    public class AdminMemberDto
    {
        public int Id { get; set; }
        public int Authority { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
    }
}