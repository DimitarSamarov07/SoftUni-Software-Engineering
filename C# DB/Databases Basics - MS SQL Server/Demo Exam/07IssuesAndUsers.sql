SELECT I.Id, CONCAT(Username, ' : ', Title) AS [IssueAssignee]
FROM Issues I
         JOIN Users U on I.AssigneeId = U.Id
ORDER BY I.Id DESC, AssigneeId