using Com.Cos.Infrastructure.Config;
using FsLib.Tencent.QCloud.SDK.Api;
using FsLib.Tencent.QCloud.SDK.ResponseModels;
using System;
using System.IO;

namespace Com.Cos.Infrastructure.Tencent
{
    public class QCloudHelper
    {
        private readonly CosCloud _cloud;
        private readonly string _bucketName;
        public QCloudHelper()
        {
            _cloud = new CosCloud(QCloudConfig.AppId.ToInt32(), QCloudConfig.SecretId, QCloudConfig.SecretKey);
            _bucketName = QCloudConfig.BucketName;
        }
        /// <summary>
        /// 上传图片到COS
        /// </summary>
        /// <param name="remoteDir">服务器目录</param>
        /// <param name="fileName">服务器文件名，不包括后缀</param>
        /// <param name="localStream">本地文件路径</param>
        /// <returns></returns>
        public UploadFileResponseModel UploadFile(string remoteDir, string fileName, Stream localStream)
        {
            localStream.Seek(0L, SeekOrigin.Begin);
            var result = _cloud.UploadFile(_bucketName, remoteDir + fileName, localStream);

            return result;
        }
    }
}