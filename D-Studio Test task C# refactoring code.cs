using System;
using System.Collections.Generic;
// previous code smells:
// duplicate code - to use methods or classes to divide responsibilities
// god method, long method - to divide the code into areas of responsibility and put this into classes
// switch statements - to use factory pattern
// shotgun surgery - to move existing class behaviors into a single class
// comments - to rename the method to make it clear by its name what it does (if there is no method, put the code section in the method).

class RequestConstantsType
{
	public const string TickDatapoints = "Tick Datapoints";
	public const string TickDays = "Tick Days";
	public const string TickTimeframe = "Tick Timeframe";
	public const string IntervalDatapoints = "Interval Datapoints";
	public const string IntervalDays = "Interval Days";
	public const string IntervalTimeframe = "Interval Timeframe";
	public const string DailyDatapoints = "Daily Datapoints";
	public const string DailyTimeframe = "Daily Timeframe";
	public const string WeeklyDatapoints = "Weekly Datapoints";
	public const string MonthlyDatapoints = "Monthly Datapoints";
}

class RequestFactory
{
	public static string BuildRequestString(HistoryRequest request)
	{
		ArgumentNullException.ThrowIfNull(request);
		string templateRequest = GetRequest(request.RequestType);
		List<string> formattedRequest = [];
		string[] templateRequestFields = templateRequest.Split(',', StringSplitOptions.RemoveEmptyEntries);
		foreach (string templateField in templateRequestFields)
		{
			string fieldValue = templateField switch
			{
				TemplateContantsRequest.SYMBOL => request.Symbol,
				TemplateContantsRequest.BEGINDATEBEGINTIME => request.BeginDateTime,
				TemplateContantsRequest.ENDDATEENDTIME => request.EndDateTime,
				TemplateContantsRequest.MAXDATAPOINTS => request.Datapoints,
				TemplateContantsRequest.BEGINFILTERTIME => request.BeginFilterTime,
				TemplateContantsRequest.ENDFILTERTIME => request.EndFilterTime,
				TemplateContantsRequest.BEGINDATE => request.BeginDateTime,
				TemplateContantsRequest.ENDDATE => request.EndDateTime,
				TemplateContantsRequest.DIRECTION => request.Direction,
				TemplateContantsRequest.REQUESTID => request.RequestID,
				TemplateContantsRequest.DATAPOINTSPERSEND => request.Datapoints,
				TemplateContantsRequest.INTERVAL => request.Interval,
				TemplateContantsRequest.INTERVALTYPE => request.IntervalType,
				TemplateContantsRequest.TIMESTAMPLABEL => request.BoxTimeStamp,
				TemplateContantsRequest.NUMDATAPOINTS => request.Datapoints,
				TemplateContantsRequest.NUMDAYS => request.Days,
				_ => templateField
			};

			formattedRequest.Add(fieldValue);
		}

		return $"{string.Join(",", formattedRequest)}\r\n";
	}

	private static string GetRequest(string requestType)
	{

		return requestType switch
		{
			RequestConstantsType.TickDatapoints => TICKDATAPOINTS,
			RequestConstantsType.TickDays => TICKDAYS,
			RequestConstantsType.TickTimeframe => TICKTIMEFRAME,
			RequestConstantsType.IntervalDatapoints => INTERVALDATAPOINTS,
			RequestConstantsType.IntervalDays => INTERVALDAYS,
			RequestConstantsType.IntervalTimeframe => INTERVALTIMEFRAME,
			RequestConstantsType.DailyDatapoints => DAILYDATAPOINTS,
			RequestConstantsType.DailyTimeframe => DAILYTIMEFRAME,
			RequestConstantsType.WeeklyDatapoints => WEEKLYDATAPOINTS,
			RequestConstantsType.MonthlyDatapoints => MONTHLYDATAPOINTS,
			_ => throw new NotFoundException()
		};
	}
}

record HistoryRequest(
	string RequestType,
	string Symbol,
	string Interval,
	string Days,
	string Datapoints,
	string BeginFilterTime,
	string EndFilterTime,
	string BeginDateTime,
	string EndDateTime,
	string Direction,
	string RequestID,
	string DatapointsPerSend,
	string IntervalType,
	string TimeStamp
);

static class TemplateContantsRequest
{
	public const string SYMBOL = nameof(SYMBOL);
	public const string BEGINDATEBEGINTIME = nameof(BEGINDATEBEGINTIME);
	public const string ENDDATEENDTIME = nameof(ENDDATEENDTIME);
	public const string MAXDATAPOINTS = nameof(MAXDATAPOINTS);
	public const string BEGINFILTERTIME = nameof(BEGINFILTERTIME);
	public const string ENDFILTERTIME = nameof(ENDFILTERTIME);
	public const string BEGINDATE = nameof(BEGINDATE);
	public const string ENDDATE = nameof(ENDDATE);
	public const string DIRECTION = nameof(DIRECTION);
	public const string REQUESTID = nameof(REQUESTID);
	public const string DATAPOINTSPERSEND = nameof(DATAPOINTSPERSEND);
	public const string INTERVAL = nameof(INTERVAL);
	public const string INTERVALTYPE = nameof(INTERVALTYPE);
	public const string TIMESTAMPLABEL = nameof(TIMESTAMPLABEL);
	public const string NUMDATAPOINTS = nameof(NUMDATAPOINTS);
	public const string NUMDAYS = nameof(NUMDAYS);
	
	public const string TICKDATAPOINTS = $"HTX,{SYMBOL},{NUMDATAPOINTS},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND}";
	public const string TICKDAYS = $"HTD,{SYMBOL},{NUMDAYS},{MAXDATAPOINTS},{BEGINFILTERTIME},{ENDFILTERTIME},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND}";
	public const string TICKTIMEFRAME = $"HTT,{SYMBOL},{BEGINDATEBEGINTIME},{ENDDATEENDTIME},{MAXDATAPOINTS},{BEGINFILTERTIME},{ENDFILTERTIME},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND}";
	public const string INTERVALDATAPOINTS = $"HIX,{SYMBOL},{INTERVAL},{NUMDATAPOINTS},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND},{INTERVALTYPE},{BOXTIMESTAMP}";
	public const string INTERVALDAYS = $"HID,{SYMBOL},{INTERVAL},{NUMDAYS},{MAXDATAPOINTS},{BEGINFILTERTIME},{ENDFILTERTIME},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND},{INTERVALTYPE},{TIMESTAMPLABEL}";
	public const string INTERVALTIMEFRAME = $"HIT,{SYMBOL},{INTERVAL},{BEGINDATEBEGINTIME},{ENDDATEENDTIME},{MAXDATAPOINTS},{BEGINFILTERTIME},{ENDFILTERTIME},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND},{INTERVALTYPE},{TIMESTAMPLABEL}";
	public const string DAILYDATAPOINTS = $"HDX,{SYMBOL},{NUMDATAPOINTS},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND}";
	public const string DAILYTIMEFRAME = $"HDT,{SYMBOL},{BEGINDATE},{ENDDATE},{MAXDATAPOINTS},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND}";
	public const string WEEKLYDATAPOINTS = $"HWX,{SYMBOL},{NUMDATAPOINTS},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND}";
	public const string MONTHLYDATAPOINTS = $"HMX,{SYMBOL},{NUMDATAPOINTS},{DIRECTION},{REQUESTID},{DATAPOINTSPERSEND}";	
}


private void btnGetData_Click(object sender, EventArgs e)
{
	try
	{
		lstData.Items.Clear();
		HistoryRequest historyRequest = new HistoryRequest()
		{
			RequestType = cboHistoryType.Text,
			Symbol = txtSymbol.Text,
			Interval = txtInterval.Text,
			Days = txtDays.Text,
			Datapoints = txtDatapoints.Text,
			BeginFilterTime = txtBeginFilterTime.Text,
			EndFilterTime = txtEndFilterTime.Text,
			BeginDateTime = txtBeginDateTime.Text,
			EndDateTime = txtEndDateTime.Text,
			Direction = txtDirection.Text,
			RequestID = txtRequestID.Text,
			DatapointsPerSend = txtDatapointsPerSend.Text,
			IntervalType = rbVolume.Checked ? "v" : rbTick.Checked ? "t" : "s",
			TimeStamp = chkBoxTimeStamp.Checked ? "1" : "0"
		};


		string formattedRequest = RequestFactory.BuildRequestString(historyRequest);
		ServiceFacade.SendRequestToIQFeed(formattedRequest);
	}
	catch (Exception ex)
	{
		string errorRequest = $"Error Processing Request.\r\nRequest type selected was: {cboHistoryType.Text}";
		UpdateListview(errorRequest);
	}
	finally
	{
		ServiceFacade.WaitForData("History");
	}
}
