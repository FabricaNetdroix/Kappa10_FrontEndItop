CREATE PROCEDURE `usp_..._...` (
	in p_accion tinyint,
	in p_...
    )
BEGIN
	if p_accion = 1 then 
    begin -- Insert
		
		
		select LAST_INSERT_ID();
    end;
    
    elseif p_accion = 2 then
    begin -- Select
    
    end;
    
    elseif p_accion = 3 then
    begin -- Update
    
    end;
    
    elseif p_accion = 4 then
    begin -- Delete
    
    end;
    
    end if;
END $$