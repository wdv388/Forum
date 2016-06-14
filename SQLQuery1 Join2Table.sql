GO
USE [c:\users\max\documents\visual studio 2012\Projects\Forum\Forum\App_Data\DatabaseForum.mdf];
GO
select Exten1.ID as ID ,
Exten1.Author as Author,
Exten1.Text as Text,
Exten2.Author as Authoranswer,
Exten2.Text as Answertext,
Exten2.DiscusID as Discusid
from DiscusНабор as Exten1
inner join AnswerНабор as Exten2

on  Exten1.ID=Exten2.DiscusID
