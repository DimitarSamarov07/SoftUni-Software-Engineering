SELECT Username, AVG(Size) AS [Size]
FROM Users
         JOIN Commits C on Users.Id = C.ContributorId
         JOIN Files F on C.Id = F.CommitId
GROUP BY Username
ORDER BY Size DESC, Username