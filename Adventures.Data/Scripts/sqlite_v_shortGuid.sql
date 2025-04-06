/*
CREATE VIEW v_shortGuid 
AS 
select SUBSTR(UUID, 0, 8)||'-'||SUBSTR(UUID,8,4)||'-'||SUBSTR(UUID,12,4)||'-'||SUBSTR(UUID,16)
from (
select lower(hex(randomblob(16))) AS UUID 
);
*/