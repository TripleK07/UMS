using System;
using UMS.Entities;
namespace UMS.Models
{
	public class ResponseMsg
	{
		public String StatusCode { get; set; }
		public String Message { get; set; }
		public IEnumerable<Object>? Data { get; set; }

		public ResponseMsg(String statusCode, String message, IEnumerable<Object>? data)
		{
			StatusCode = statusCode;
			Message = message;
			Data = data;
		}
	}
}

