﻿-- Version = 1.0.0
alter Procedure CK.sAclDestroy
(
    @ActorId int,
    @AclId int
)
as begin

	if @ActorId <= 0 throw 50000, 'Security.AnonymousNotAllowed', 1;

	--[beginsp]

	delete from CK.tAclConfigMemory where AclId = @AclId;
	delete from CK.tAclConfig where AclId = @AclId;
	delete from CK.tAcl where AclId = @AclId;

	--[endsp]
end
