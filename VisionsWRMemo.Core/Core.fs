namespace VisionsWRMemo.Core


open System
open System.Net.Http
open System.Text
open OfficeOpenXml
open System.IO
open OfficeOpenXml.Style
open System.Diagnostics
open ClosedXML
open ClosedXML.Excel
open ClosedXML.SimpleSheets

module Domain = 
    type InspectionTask = {
        AssignedUser:string
        DueDate:string
        EquipNum:string
        EquipType:string
        InspectorName:string
        JobFileNo:string
        MemoTitle:string
        PlantNum:string
        ProbDesc:string
        ProposedDisp:string
        WorkDesc:string
        WorkOrderNo:string
        ActivityCode:string
        ERPNotificationRequired:string
        MemoType:string
        Department:string
        SurfacePrep:string
        PriorityCode:string
        Success:bool
        MemoNumber:int
        Message:string
    }


module ExcelData = 
    open Domain

    let private license() = ExcelPackage.LicenseContext <- LicenseContext.NonCommercial;

    let private addInstructions (package:ExcelPackage) = 
        let sheet = package.Workbook.Worksheets.Add("Instructions")

        // COL | ROW
        sheet.Cells[1,1].Value <- "Column and Text Colourization:"
        sheet.Cells[1,1].Style.Font.Bold <-true

        sheet.Cells[2,1].Value <- "1) Columns with RED labels are part of a record's unique identification."
        sheet.Cells[3,1].Value <- "• These fields must be filled in with valid data in order to create a new record in Visions."
        
        sheet.Cells[5,1].Value <- "F3 Lists: "
        sheet.Cells[5,1].Style.Font.Bold <-true
        sheet.Cells[6,1].Value <- "Extent, Priority Code, SurfacePrep, Department, Memo Type, Activity Code and Assigned Inspector values must be present in thier associated F3 lists in Visions"
        
        sheet.Cells[8,1].Value <- "ERP Notification: "
        sheet.Cells[8,1].Style.Font.Bold <-true
        sheet.Cells[9,1].Value <- "Defaults to 'NO' if work order generation is required enter 'YES' or 'yes'."
        
        sheet.Cells[11,1].Value <- "Inspector Name:"
        sheet.Cells[11,1].Style.Font.Bold <-true
        sheet.Cells[12,1].Value <- "Defaults to current user, use this column to overide default."
        
        sheet.Cells[15,1].Value <- "Memo Type:"
        sheet.Cells[15,1].Style.Font.Bold <-true
        sheet.Cells[16,1].Value <- "Enter 'WR' for Work Request or 'IT' Inspection Task. Defaults to WR."
        
        sheet.Cells[15,1].Value <- "Extent:"
        sheet.Cells[15,1].Style.Font.Bold <-true
        sheet.Cells[16,1].Value <- "Defaults to 'Partial'. Curently does not support 'Full'."
        

        package

    let private addMappings (package:ExcelPackage) = 
        // COL | ROW
        let sheet = package.Workbook.Worksheets.Add("Mapping")
        sheet.Cells[1,1].Value <- "Plant No."
        sheet.Cells[1,1].Style.Font.Color.SetColor(System.Drawing.Color.Red)
        sheet.Cells[1,1].Style.Border.BorderAround(ExcelBorderStyle.Medium)
        
        sheet.Cells[1,2].Value <- "Equipment No."
        sheet.Cells[1,2].Style.Font.Color.SetColor(System.Drawing.Color.Red)
        sheet.Cells[1,2].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,3].Value <- "Equipment Type"
        sheet.Cells[1,3].Style.Font.Color.SetColor(System.Drawing.Color.Red)
        sheet.Cells[1,3].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,4].Value <- "Memo Title"
        sheet.Cells[1,4].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,5].Value <- "Job File No."
        sheet.Cells[1,5].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,6].Value <- "Due Date"
        sheet.Cells[1,6].Style.Numberformat.Format <- "yyyy-mm-dd";
        sheet.Cells[1,6].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,7].Value <- "ERP Notification Required"
        sheet.Cells[1,7].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,8].Value <- "Activity Code"
        sheet.Cells[1,8].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,9].Value <- "Assigned User"
        sheet.Cells[1,9].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,10].Value <- "Inspector Name"
        sheet.Cells[1,10].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,11].Value <- "Extent"
        sheet.Cells[1,11].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,12].Value <- "Problem Desc."
        sheet.Cells[1,12].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,13].Value <- "Proposed Disposition"
        sheet.Cells[1,13].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,14].Value <- "Work Desc."
        sheet.Cells[1,14].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,15].Value <- "Work Order No."
        sheet.Cells[1,15].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,16].Value <- "Memo Type."
        sheet.Cells[1,16].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,17].Value <- "Department"
        sheet.Cells[1,17].Style.Border.BorderAround(ExcelBorderStyle.Medium)
        
        sheet.Cells[1,18].Value <- "Surface Prep"
        sheet.Cells[1,18].Style.Border.BorderAround(ExcelBorderStyle.Medium)

        sheet.Cells[1,19].Value <- "Priority Code"
        sheet.Cells[1,19].Style.Border.BorderAround(ExcelBorderStyle.Medium)
        
        package         

    let launchTemplate filePath = 
        try
            let p = new Process();
            let processStartInfo = new ProcessStartInfo(filePath)
            processStartInfo.UseShellExecute <- true
            p.StartInfo <- processStartInfo
            
            p.Start();
        with
        | enx -> false

    let createTemplate() = 
        license()
        let filePath = 
            let temp = Path.GetTempPath()
            Path.Join([|temp; $"""template_{DateTime.UtcNow.ToString("yyyy_MM_dd_H_mm_ss")}.xlsx"""|])

        use package = new ExcelPackage(filePath)
        
        let instructions = package |> addInstructions |> addMappings

        instructions.Save()
        
        launchTemplate filePath |> ignore

        filePath

    let memoListPath = 
        let temp = Path.GetTempPath()
        Path.Join([|temp; $"""MemoList_{DateTime.UtcNow.ToString("yyyy_MM_dd_H_mm_ss")}.xlsx"""|])


    let createSuccessReport(tasks:InspectionTask list) = 
               
        let successfullTasks = 
            tasks |> List.filter(fun x-> x.Success = true)

        let excelFile = Excel.createFrom("Memos",successfullTasks, [
            Excel.field(fun (task:InspectionTask) -> task.EquipNum).header("Equipment No.")
                .headerHorizontalAlignment(XLAlignmentHorizontalValues.Center)
                .verticalAlignment(XLAlignmentVerticalValues.Top)
                .horizontalAlignment(XLAlignmentHorizontalValues.Left)
            Excel.field(fun (task:InspectionTask) -> task.MemoNumber).header("Memo No.")
                .headerHorizontalAlignment(XLAlignmentHorizontalValues.Center)
                .verticalAlignment(XLAlignmentVerticalValues.Top)
                .horizontalAlignment(XLAlignmentHorizontalValues.Left)
        ])
        System.IO.File.WriteAllBytes(memoListPath, excelFile)
        launchTemplate memoListPath |> ignore
        tasks

    let private removeChar (value:string) = 
        value.Replace("/","-")
        value.Replace("&","and")
        value.Replace("@","at")
        value.Replace("<"," ")
        value.Replace(">"," ")
        value.Replace("#"," ")


    let extractData (filePath:string)(user:string) = 
        license()
        use package = new ExcelPackage(filePath)

        let data = ResizeArray<Domain.InspectionTask>()

        let sheet = 
            if package.Compatibility.IsWorksheets1Based then
                package.Workbook.Worksheets[2]
            else
                package.Workbook.Worksheets[1]

        let startRow = sheet.Dimension.Start.Row + 1;
        let endRow = sheet.Dimension.End.Row;
        // ROW | COL
        for x = startRow to endRow do

            let plantNum=
                try 
                    if String.IsNullOrEmpty(sheet.Cells[x,1].Value.ToString()) |> not then
                        sheet.Cells[x,1].Value.ToString() 
                        |> removeChar
                    else
                        ""
                with
                |exn -> ""
                

            let equipNum = 
                try
                     if String.IsNullOrEmpty(sheet.Cells[x,2].Value.ToString()) |> not then
                         sheet.Cells[x,2].Value.ToString()
                         |> removeChar
                     else
                         ""
                with
                | _ -> ""

            let equipType =
                try
                     if String.IsNullOrEmpty(sheet.Cells[x,3].Value.ToString()) |> not then
                         sheet.Cells[x,3].Value.ToString()
                         |> removeChar
                     else
                         ""
                with
                | _ -> ""

            let memoTitle=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,4].Value.ToString()) |> not then
                        sheet.Cells[x,4].Value.ToString()
                        |> removeChar
                    else
                        ""
                with
                | _ -> ""

            let jobFileNo=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,5].Value.ToString()) |> not then
                        sheet.Cells[x,5].Value.ToString()
                        |> removeChar
                    else
                        ""
                with
                | _ -> ""

            let dueDate =
                try
                     match sheet.Cells[x,6].Value.ToString() |>DateTime.TryParse  with
                     | (true,date) -> date.ToString("yyyy-MM-dd")
                     | _ -> DateTime.UtcNow.ToString("yyyy-MM-dd")
                with
                | _ -> DateTime.UtcNow.ToString("yyyy-MM-dd")

            let erpRequired=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,7].Value.ToString()) |> not then
                        if sheet.Cells[x,7].Value.ToString().ToUpper() = "YES" then
                             "YES"
                        else "NO"
                    else
                        "NO"
                with
                | _ -> "NO"

            let activityCode=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,8].Value.ToString()) |> not then
                        sheet.Cells[x,8].Value.ToString()
                        |> removeChar
                    else
                        ""
                with
                | _ -> ""

            let assignedUser = 
                try
                     if String.IsNullOrEmpty(sheet.Cells[x,9].Value.ToString()) |> not then
                         sheet.Cells[x,9].Value.ToString()
                         |> removeChar
                     else
                         user       
                with
                | _ -> ""
            
            let inspectorName=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,10].Value.ToString()) |> not then
                        sheet.Cells[x,10].Value.ToString()
                        |> removeChar
                    else
                        ""
                with
                | _ -> ""
            
            let probDesc=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,12].Value.ToString()) |> not then
                        sheet.Cells[x,12].Value.ToString()
                        |> removeChar
                    else
                        ""
                with
                | _ -> ""

            let proposedDisp=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,13].Value.ToString()) |> not then
                        sheet.Cells[x,13].Value.ToString()
                        |> removeChar
                    else
                        ""
                with
                | _ -> ""

            let workDesc=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,14].Value.ToString()) |> not then
                        sheet.Cells[x,14].Value.ToString()
                        |> removeChar
                    else
                        ""
                with
                | _ -> ""

            let workOrderNo=
                try
                    if String.IsNullOrEmpty(sheet.Cells[x,15].Value.ToString()) |> not then
                        sheet.Cells[x,15].Value.ToString()
                        |> removeChar
                    else
                        ""
                with
                | _ -> ""

            let memoType=
                try
                     if String.IsNullOrEmpty(sheet.Cells[x,16].Value.ToString()) |> not then
                         sheet.Cells[x,16].Value.ToString()
                         |> removeChar
                     else
                         "WR"
                with
                | _ -> "WR"

            let department=
                try
                     if String.IsNullOrEmpty(sheet.Cells[x,17].Value.ToString()) |> not then
                         sheet.Cells[x,17].Value.ToString()
                         |> removeChar
                     else
                         ""
                with
                | _ -> ""

            let surfacePrep=
                try
                     if String.IsNullOrEmpty(sheet.Cells[x,18].Value.ToString()) |> not then
                         sheet.Cells[x,18].Value.ToString()
                         |> removeChar
                     else
                         ""
                with
                | _ -> ""

            let priorityCode=
                try
                     if String.IsNullOrEmpty(sheet.Cells[x,19].Value.ToString()) |> not then
                         sheet.Cells[x,19].Value.ToString()
                         |> removeChar
                     else
                         ""
                with
                | _ -> ""
            
            if String.IsNullOrEmpty plantNum || String.IsNullOrEmpty equipNum || String.IsNullOrEmpty equipType then
                 let newWork :Domain.InspectionTask= {
                     AssignedUser=assignedUser
                     DueDate=dueDate
                     EquipNum= $"Equipment No. was not provided row:{x} col:2"
                     EquipType=""
                     InspectorName=inspectorName
                     JobFileNo=jobFileNo
                     MemoTitle=memoTitle
                     PlantNum=""
                     ProbDesc=probDesc
                     ProposedDisp=proposedDisp
                     WorkDesc=workDesc
                     WorkOrderNo=workOrderNo
                     ActivityCode=activityCode
                     ERPNotificationRequired= erpRequired
                     MemoType=memoType
                     Department=department
                     SurfacePrep=surfacePrep
                     PriorityCode=priorityCode
                     Success=false
                     MemoNumber=0
                     Message="Request unsent."
                 }
                 data.Add(newWork)
            else
                 let newWork :Domain.InspectionTask= {
                     AssignedUser=assignedUser
                     DueDate=dueDate
                     EquipNum=equipNum
                     EquipType=equipType
                     InspectorName=inspectorName
                     JobFileNo=jobFileNo
                     MemoTitle=memoTitle
                     PlantNum=plantNum
                     ProbDesc=probDesc
                     ProposedDisp=proposedDisp
                     WorkDesc=workDesc
                     WorkOrderNo=workOrderNo
                     ActivityCode=activityCode
                     ERPNotificationRequired= erpRequired
                     MemoType=memoType
                     Department=department
                     SurfacePrep=surfacePrep
                     PriorityCode=priorityCode
                     Success=false
                     MemoNumber=0
                     Message="Request unsent."
                 }
                 data.Add(newWork)
            
        data |> List.ofSeq

module Visions = 
    open Domain

    let requestUserList(siteName:string)(userName:string)(password:string) = 
        if  String.IsNullOrEmpty siteName ||
            String.IsNullOrEmpty userName ||
            String.IsNullOrEmpty password 

        then
            failwith "Invalid login attempt."
        
        else 
            $"""
                <x:Envelope
                    xmlns:x="http://schemas.xmlsoap.org/soap/envelope/"
                    xmlns:met="http://metegrity.com">
                    <x:Header/>
                    <x:Body>
                        <met:QueryUsers>
                            <met:SiteName>{siteName}</met:SiteName>
                            <met:UserName>{userName}</met:UserName>
                            <met:Password>{password}</met:Password>
                        </met:QueryUsers>
                    </x:Body>
                </x:Envelope>
            """
            
    let createWorkRequestMemos (siteName:string)(userName:string)(password:string)(data: InspectionTask list) = 
        data
        |> List.map(fun x ->
            
            if String.IsNullOrEmpty siteName ||
               String.IsNullOrEmpty userName ||
               String.IsNullOrEmpty password ||
               String.IsNullOrEmpty x.EquipNum ||
               String.IsNullOrEmpty x.PlantNum ||
               String.IsNullOrEmpty x.EquipType ||
               String.IsNullOrEmpty x.MemoType  
            then
                "",{x with Success=false; Message = "Verify essential fields were provided." }
            else

                $"""
                    <x:Envelope xmlns:x="http://schemas.xmlsoap.org/soap/envelope/"
                                xmlns:met="http://metegrity.com">
                    <x:Header/>
                        <x:Body>
                            <met:CreateWorkMemo>
                            <met:SiteName>{siteName}</met:SiteName>
                            <met:UserName>{userName}</met:UserName>
                            <met:Password>{password}</met:Password>
                            <met:EquipNum>{x.EquipNum}</met:EquipNum>
                            <met:PlantNum>{x.PlantNum}</met:PlantNum>
                            <met:EquipType>{x.EquipType}</met:EquipType>
                            <met:MemoType>{x.MemoType}</met:MemoType>
                            <met:Values>
                            [Values]
                                [Value field='MemoTitle']{x.MemoTitle}[/Value]
                                [Value field='JobFileNo']{x.JobFileNo}[/Value]
                                [Value field='WorkOrderNo']{x.WorkOrderNo}[/Value]
                                [Value field='DueDate' fmt='yyyy-MM-dd']{x.DueDate}[/Value]
                                [Value field='ERPNotifReqd']No[/Value]
                                [Value field='ActivityCode']{x.ActivityCode}[/Value]
                                [Value field='AssignedUser']{x.AssignedUser}[/Value]
                                [Value field='InspectorName']{x.InspectorName}[/Value]
                                [Value field='Extent']Partial[/Value]
                                [Value field='ProbDesc']{x.ProbDesc}[/Value]
                                [Value field='ProposedDisp']{x.ProposedDisp}[/Value]
                                [Value field='WorkDesc']{x.WorkDesc}[/Value]
                                [Value field='WRDepartment']{x.Department}[/Value]
                                [Value field='SurfacePrep']{x.SurfacePrep}[/Value]
                                [Value field='PriorityCode']{x.PriorityCode}[/Value]
                            [/Values]
                            </met:Values>
                            </met:CreateWorkMemo>
                        </x:Body>
                    </x:Envelope>
            
                """,x )



module Http =
    open ExcelData
    open Visions
    open Domain
    open FSharp.Data
    

    type Action = 
        | QueryUsers 
        | CreateWorkMemo 
        with 
            member this.value = 
                match this with
                | QueryUsers     -> "QueryUsers"
                | CreateWorkMemo -> "CreateWorkMemo"

    [<Literal>]
    let private visionsResponse = 
        """
        <s:Envelope
        xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
        <s:Body>
            <CreateWorkMemoResponse
                xmlns="http://metegrity.com">
                <CreateWorkMemoResult>false</CreateWorkMemoResult>
                <MemoNo a:nil="true"
                    xmlns:a="http://www.w3.org/2001/XMLSchema-instance"/>
                    <ErrorMsg>Specified equipment record not found.</ErrorMsg>
                </CreateWorkMemoResponse>
            </s:Body>
        </s:Envelope>
        """

    [<Literal>]
    let private loginResponse = 
        """
            <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
                <s:Body>
                    <QueryUsersResponse
                        xmlns="http://metegrity.com">
                        <QueryUsersResult>true</QueryUsersResult>
                        <UserList>USER,user</UserList>
                        <ErrorMsg>Operation successful.</ErrorMsg>
                    </QueryUsersResponse>
                </s:Body>
            </s:Envelope>
        """

    type QueryUserApiResponse = {
        QueryUsersResult:bool
        UserList:string
        ErrorMsg:string
    }
    
    type VisApiResponse = {
        Success:bool
        MemoNumber:int
        Message:string
    }
    
    type VisResponse = XmlProvider<visionsResponse>
    type QueryUserResponse = XmlProvider<loginResponse>
    
    let private parseQueryUserResponse(xmlString:string) = 
        try
            let xml = QueryUserResponse.Parse(xmlString)
            let result :QueryUserApiResponse = 
                { 
                    QueryUsersResult=xml.Body.QueryUsersResponse.QueryUsersResult
                    UserList= xml.Body.QueryUsersResponse.UserList
                    ErrorMsg=xml.Body.QueryUsersResponse.ErrorMsg
                }
            result

        with
        | exn ->
            { 
                QueryUsersResult=false
                UserList= ""
                ErrorMsg= "Login failed"
            }

    let private parseVisApiResponse(xmlString:string)(task:InspectionTask) = 
        try
            let xml = VisResponse.Parse(xmlString)
            let result :InspectionTask = 
                { task with
                    Success=xml.Body.CreateWorkMemoResponse.CreateWorkMemoResult
                    MemoNumber=
                        match Int32.TryParse xml.Body.CreateWorkMemoResponse.MemoNo.XElement.Value with
                        | true,value -> value
                        | _ -> 0
                    Message=xml.Body.CreateWorkMemoResponse.ErrorMsg
                }
            result

        with
        | exn ->
            { task with
                Success=false
                MemoNumber=0
                Message= 
                $"""There was an error processing your request.
                This error occured when trying to parse the response from the visions API.
                {Environment.NewLine}
                {exn.Message}"""
            }

    let private client() = new HttpClient()
        
    let private xmlContent(action:string) (value:string) =
        let content = new StringContent(value, Encoding.UTF8, "text/xml")
        content.Headers.Clear()
        content.Headers.Add("Content-Type","text/xml; charset=utf-8")
        content.Headers.Add("SOAPAction",$"http://metegrity.com/IVisAPI/{action}")
        content

    let private endpoint (server:string) = 
        try
            let s = server.Split(".")
            $"http://{s[0]}:7137/VisAPI/VisAPI_BH"
        with
        | exn -> failwith "Invalid server domain."



    let private createWorRequestMemo (requestUri:string)(task:InspectionTask)(content:string) = 
        async { 
            try
                if String.IsNullOrEmpty content then
                    return {task with Success= false;}
                else
                    let xmlHttpContent  = xmlContent CreateWorkMemo.value content
                    let! response = client().PostAsync(requestUri,xmlHttpContent  ) |> Async.AwaitTask
                    let! xml = response.Content.ReadAsStringAsync() |> Async.AwaitTask
                    return parseVisApiResponse xml task    
            with
            | exn -> return { task with 
                                Success= false
                                Message= 
                                $"""
                                There was an error processing your request.
                                This error occured while trying to create the Memo in Visions.
                                {Environment.NewLine}
                                {exn.Message}
                                {exn.InnerException}""";}

        } |> Async.RunSynchronously




    /// Create a WR or IT for each item in provided excel sheet in visions.
    /// Visions does not support running these request in parallel, they have implemented an internal 
    /// pooling mechanism for the database access, however it appears to exhaust connections and causes
    /// the whole server to timeout.
    let createTask (path: string)(siteName:string)(userName:string)(password:string)(server:string) =
        try
            let server = endpoint server
            let result = 
                extractData path userName
                |> createWorkRequestMemos siteName userName password
                |> List.map( fun (content,task) -> createWorRequestMemo server task content )
                |> createSuccessReport
                |> List.filter(fun x-> x.Success = false)
                |> ResizeArray
            result
        with
        | exn -> raise exn

    let login (siteName:string)(userName:string)(password:string)(server:string) = 
        async { 
            try
                let content = 
                    Visions.requestUserList siteName userName password
                    |> xmlContent QueryUsers.value 
                let requestUri = endpoint server
                let! response = client().PostAsync(requestUri,content) |> Async.AwaitTask
                let! xml = response.Content.ReadAsStringAsync() |> Async.AwaitTask
                return parseQueryUserResponse xml     
            with
            | exn -> return {QueryUsersResult=false; UserList=""; ErrorMsg=exn.Message}

        } |> Async.RunSynchronously
