$(document).ready(function() {
	

	$("#btnSave").click(function() {
		if(isInsert)
		{
			//新增数据字典主表信息
			InsertDictionaryInfo();
		}
		else
		{
			//修改数据字典主表信息
			UpdateDictionaryInfo();
		}
	});
	$("#addBtn").click(function() {
			isInsert=true;
			//清空字典信息弹窗内数据
			ClearDataInfo();
			$(".form-horizontal").show();

	});
	$("#closeBox").click(function() {
			$(".form-horizontal").hide();
			
		});
	$("#selectBtn").click(function() {
		/*
		var requrl = "http://192.168.15.154:8280/imageUpload/forBase64";
		var jsonParam = {"code": "10002","version": "1.0","jsonStr": {}};
		var jsonstr = setJson(null, "content", "123456");
		jsonstr = setJson(jsonstr, "suffix", "jpg");
		jsonParam.jsonStr = jsonstr;
		jQuery.ajaxRequest(requrl, JSON.stringify(jsonParam), callback_UpdateDictionaryInfo);
		*/
		
		GetDataInfoList();
	});
});
//是否为新增标识
var isInsert=false;
//清空字典信息弹窗内数据
function ClearDataInfo()
{
		$("#dName").val("");
		$("#dCode").val("");
		$("#dictionary").val("");
		$("#dString1").val("");
		$("#dString2").val("");
		$("#dString3").val("");
		$("#dString4").val("");
		$("#dString5").val("");
		$("#dSeqno").val("");
		$("#dRemark").val("");
		$("#selectIsValid").find("option[value=1]").attr('selected', true);
}

//获取字典列表数据开始///////////////////////////////////////////////////////////////////////////////
/*
 * 功能：获取所有的码表信息
 * 创建人：liql
 * 创建时间：2016-5-9
 */
function GetDataInfoList() {
	var requrl = baseUrl+"DataDictionaryService/GetDictionaryList";
	jQuery.ajaxRequest(requrl, "", callback_getdatainfo);
};
/*
 * 功能：码表信息回调
 * 创建人：liql
 */
function callback_getdatainfo(data) {
	console.log(jQuery.parseJSON(data));
	$("#dataList").html('');
	var dataList = jQuery.parseJSON(data);
	
	if(dataList == undefined || dataList == null || dataList.rspCode != '000') {
		alert("获取数据失败 " + dataList.rspDesc);
	} else {
		var templte = $("#dataListTemplate").html();
		Mustache.parse(templte);
		var testA = new Array();
		if(dataList.Result != null && dataList.Result.length > 0) {
			$.each(dataList.Result, function(index, entry) {
				if(entry != null && entry != undefined) {
					var test = JSON.stringify(entry);
					if(entry.DICTIONARY_CREATED != null && entry.DICTIONARY_CREATED != undefined) {
						//var dates = Date.FromMSJsonString(entry.DICTIONARY_CREATED);//国际时间格式转正常格式
						test = setJson(test, "DICTIONARY_CREATED", new Date(entry.DICTIONARY_CREATED).format('yyyy-MM-dd'));
					}
					entry = jQuery.parseJSON(test);
					testA.push(entry);
				}
			});
		}
		dataList.Result.splice(0, dataList.Result.length);
		dataList.Result = testA;
		$("#dataList").append(Mustache.render(templte, dataList));

		$(".btnUpdate").click(function() {
			isInsert=false;
			$(".form-horizontal").show();
			GetDictionaryInfoById($(this).attr('data-id'));

		});
		
		
	}
};

//获取字典列表数据结束/////////////////////////////////////////////////////////////////////////////////

//获取字典详情数据开始///////////////////////////////////////////////////////////////////////////////
/*
 * 功能：根据id获取详细信息
 * 创建人：liql
 * 创建时间：2016-6-3
 */
function GetDictionaryInfoById(id) {
	var url = baseUrl+"DataDictionaryService/GetDictioanryInfoById/" + id;
	jQuery.ajaxRequest(url, "", callback_GetDictionaryInfoById);
};

function callback_GetDictionaryInfoById(data) {
	console.log(data);
	var datas = jQuery.parseJSON(data);
	if(datas == null || datas == undefined || datas.rspCode != '000') {
		alert(datas.rspDesc);
	} else {
		var dataValue = datas.Result;
		console.log(dataValue);
		$("#dName").val(dataValue.DICTIONARY_NAME);
		$("#dCode").val(dataValue.DICTIONARY_CODE);
		$("#dictionary").val(dataValue.DICTIONARY_ID);
		$("#dString1").val(dataValue.DICTIONARY_STRING1);
		$("#dString2").val(dataValue.DICTIONARY_STRING2);
		$("#dString3").val(dataValue.DICTIONARY_STRING3);
		$("#dString4").val(dataValue.DICTIONARY_STRING4);
		$("#dString5").val(dataValue.DICTIONARY_STRING5);
		$("#dSeqno").val(dataValue.DICTIONARY_SEQNO);
		$("#dRemark").val(dataValue.DICTIONARY_REMARK);
		$("#selectIsValid").find("option[value=" + dataValue.DICTIONARY_ISVALID + "]").attr('selected', true);
	}
};
//获取字典详情数据结束///////////////////////////////////////////////////////////////////////////////

//修改字典数据开始///////////////////////////////////////////////////////////////////////////////
/*
 * 功能：修改数据字典信息
 * 创建人：Liql
 * 创建时间：2016-6-28
 */
function UpdateDictionaryInfo() {
		var jsonParam = setJson(null, "DICTIONARY_ID", $("#dictionary").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_CODE", $("#dCode").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_NAME", $("#dName").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING1", $("#dString1").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING2", $("#dString2").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING3", $("#dString3").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING4", $("#dString4").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING5", $("#dString5").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_SEQNO", $("#dSeqno").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_SEQNO1", $("#dSeqno").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_ISVALID", $("#selectIsValid").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_REMARK", $("#dRemark").val());
		
		var url = baseUrl+"DataDictionaryService/UpdateDictionaryInfo";
		jQuery.ajaxRequest(url, jsonParam, callback_UpdateDictionaryInfo);
};
/*
 * 功能：修改数据字典回调信息
 * 创建人：liql
 * 创建时间：2016-6-28
 */
function callback_UpdateDictionaryInfo(data) {
	var result=JSON.parse(data);
//	if(result.rspCode=="000")
//	{
	alert(result.rspDesc);
	$(".form-horizontal").hide();
	GetDataInfoList();
	//}
};
//修改字典数据结束///////////////////////////////////////////////////////////////////////////////

//新增字典数据开始///////////////////////////////////////////////////////////////////////////////
/*
 * 功能：新增数据字典信息
 * 创建人：Liql
 * 创建时间：2016-6-28
 */
function InsertDictionaryInfo() {
		var jsonParam =  setJson(null, "DICTIONARY_CODE", $("#dCode").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_NAME", $("#dName").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING1", $("#dString1").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING2", $("#dString2").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING3", $("#dString3").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING4", $("#dString4").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_STRING5", $("#dString5").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_SEQNO", $("#dSeqno").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_SEQNO1", $("#dSeqno").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_ISVALID", $("#selectIsValid").val());
		jsonParam = setJson(jsonParam, "DICTIONARY_REMARK", $("#dRemark").val());
		
		var url = baseUrl+"DataDictionaryService/InsertDictionaryInfo";
		jQuery.ajaxRequest(url, jsonParam, callback_InsertDictionaryInfo);
};
/*
 * 功能：新增数据字典回调信息
 * 创建人：liql
 * 创建时间：2016-6-28
 */
function callback_InsertDictionaryInfo(data) {
	var result=JSON.parse(data);
//	if(result.rspCode=="000")
//	{
	alert(result.rspDesc);
	$(".form-horizontal").hide();
	GetDataInfoList();
	//}
};
//新增字典数据结束///////////////////////////////////////////////////////////////////////////////
