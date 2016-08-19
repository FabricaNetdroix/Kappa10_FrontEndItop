CREATE PROCEDURE `usp_..._...` (
	in p_accion tinyint,
	in p_...
    )
BEGIN
	if intaccion = 1 then 
    begin -- Insert
		
		
		select LAST_INSERT_ID();
    end;
    
    elseif intaccion = 2 then
    begin -- Select
    
    end;
    
    elseif intaccion = 3 then
    begin -- Update
    
    end;
    
    elseif intaccion = 4 then
    begin -- Delete
    
    end;
    
    end if;
END $$