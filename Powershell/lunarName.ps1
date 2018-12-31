#http://www.voidware.com/moon_phase.htm

function moon-phase
{
[CmdletBinding(
    DefaultParameterSetName="typed")]
param(
[parameter(ParameterSetName="typed",Mandatory="true")]
[int]$Year,

[parameter(ParameterSetName="typed",Mandatory="true")]
[int]$Month,

[parameter(ParameterSetName="typed",Mandatory="true")]
[int]$Day,

[parameter(ParameterSetName="dateTime")]
[datetime]$dt = (Get-Date)

)

if($PSCmdlet.ParameterSetName -eq "dateTime")
{
    $Year = $dt.Year
    $month = $dt.Month
    $Day = $dt.Day
}else{
    $dt = Get-Date -Year $Year -Month $Month -Day $Day
}    

    if ($Month -lt 3) {
        $Year--;
        $Month += 12;
    }
    ++$Month;
    [int]$yearDays = 365.25*$Year;
    [int]$monthDays = 30.6*$Month;
    $julianDays = $yearDays+$monthDays+$Day-694039.09;  # $jd is total days elapsed 
        
    $LunarDay = $julianDays % 29.53 
    

    [int]$Phase = ($LunarDay/29.53*8 +.5) % 7;	     # scale fraction from 0-8 and round by adding 0.5 
                                                             # 0 and 8 are the same so turn 8 into 0 
    
    $MonthZeroDays = ($yearDays-694039.09)%29.53;
    
    $LunarMonth = 0
    if($dt.DayOfYear -gt $MonthZeroDays){ 
    
            $LunarMonth = 1
            [int]$moreMonths = ($dt.DayOfYear - $MonthZeroDays)/29.53
            if($moreMonths -gt 0){$LunarMonth = $moreMonths + 1}
    } 
    
    



    "{0}-{1}-{2}/8" -f $Year, $LunarMonth, $Phase

    "{0}-{1}-{2}" -f $Year, $LunarMonth, [int]$LunarDay
}