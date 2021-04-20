using System;
using Newtonsoft.Json;

namespace io.rong.rong.models {
		
	/**
	 * 群组用户信息。
	 */
	public class GroupUser {
		// 用户 Id。
		[JsonProperty]
		String id;
		
		public GroupUser(String id) {
			this.id = id;
		}
		
		/**
		 * 设置id
		 *
		 */	
		public void setId(String id) {
			this.id = id;
		}
		
		/**
		 * 获取id
		 *
		 * @return String
		 */
		public String getId() {
			return id;
		}
		
		public String toString() {
	    	return JsonConvert.SerializeObject(this);
	        }
		}
}
