using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace io.rong.rong.models {
		
	/**
	 * listGagChatroomUser返回结果
	 */
	public class ListGagChatroomUserReslut {
		// 返回码，200 为正常。
		[JsonProperty]
		int code;
		// 聊天室被禁言用户列表。
		[JsonProperty]
		List<GagChatRoomUser> users;
		// 错误信息。
		[JsonProperty]
		String errorMessage;
		
		public ListGagChatroomUserReslut(int code, List<GagChatRoomUser> users, String errorMessage) {
			this.code = code;
			this.users = users;
			this.errorMessage = errorMessage;
		}
		
		/**
		 * 设置code
		 *
		 */	
		public void setCode(int code) {
			this.code = code;
		}
		
		/**
		 * 获取code
		 *
		 * @return Integer
		 */
		public int getCode() {
			return code;
		}
		
		/**
		 * 设置users
		 *
		 */	
		public void setUsers(List<GagChatRoomUser> users) {
			this.users = users;
		}
		
		/**
		 * 获取users
		 *
		 * @return List<GagChatRoomUser>
		 */
		public List<GagChatRoomUser> getUsers() {
			return users;
		}
		
		/**
		 * 设置errorMessage
		 *
		 */	
		public void setErrorMessage(String errorMessage) {
			this.errorMessage = errorMessage;
		}
		
		/**
		 * 获取errorMessage
		 *
		 * @return String
		 */
		public String getErrorMessage() {
			return errorMessage;
		}
		
		public String toString() {
	    	return JsonConvert.SerializeObject(this);
	        }
		}
}
