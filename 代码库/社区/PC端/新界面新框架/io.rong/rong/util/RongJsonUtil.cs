using Newtonsoft.Json;

namespace io.rong.rong.util {
	class RongJsonUtil {
		public static ObjType JsonStringToObj<ObjType>(string JsonString) where ObjType : class {
          	  ObjType s = JsonConvert.DeserializeObject<ObjType>(JsonString);
          	  return s;
       		}
	}
	
}