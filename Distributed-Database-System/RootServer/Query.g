////////////////////////////////////////////////////////////////////////////////////////////////////
//  Query.g:                       Grammar file which contains rules for parsing EskimoDB Query   // 
//  Platform:                      Windows 7								                      //
//  Application:                   EskimoDB - RootServer                                          //
////////////////////////////////////////////////////////////////////////////////////////////////////

/*
 * Module Operations:
 * =================
 * Defines rules for ANTLR tool in order to parse the EskimoDB queries
 * /
/*
Maintainence History:
=====================
ver 1.0 : 03 October 2011
- first release
*/
grammar Query;

options
{
	language = 'CSharp';
	output = AST;
}

@parser::header {
#pragma warning disable 0219
using edu.syr.cse784.eskimodb.rootserver;

}

@lexer::header {
using edu.syr.cse784.eskimodb.rootserver;
}

@members {
protected void mismatch(IIntStream input,int ttype,BitSet follow)
{
	throw new MismatchedTokenException(ttype,input);
}
public void recoverFromMismatchedSet(IIntStream input, RecognitionException e, BitSet follow)
{
	throw e;
}

}

@rulecatch {
	catch(RecognitionException e)
	{
		throw e;
	}
	catch(QueryParserException e)
	{
		throw e;
	}
}


/* Parser Rules*/

statement returns [Statement ret]

: create_db { retval.ret = $create_db.ret;} 
| select_db { retval.ret = $select_db.ret;}
| delete_db {retval.ret = $delete_db.ret;}
| delete_table {retval.ret = $delete_table.ret;}
| empty_table {retval.ret = $empty_table.ret;}
| mod_table {retval.ret = $mod_table.ret;}
| create_table {retval.ret = $create_table.ret;}
| select_rows { retval.ret = $select_rows.ret;}
| insert_row {retval.ret = $insert_row.ret;}
| rename_table {retval.ret = $rename_table.ret;}
| update_row { retval.ret = $update_row.ret;}
| delete_row { retval.ret = $delete_row.ret;}
| rename_column {retval.ret = $rename_column.ret;};


create_table returns[CreateTable ret]
@init
{
	retval.ret = new CreateTable();
	retval.ret.SetStatementType(StatementType.CREATE_TABLE);
}
:('create table'|'CREATE TABLE')table_name'(' tlist ');'
{
retval.ret.SetTableName($table_name.ret.GetTableName());
retval.ret.SetList($tlist.ret);
};


tlist returns[ColumnList ret]
@init
{
       retval.ret = new ColumnList();
}
 :t1 = tcolumn{
 retval.ret.AddToList($t1.ret);
 }
 (',' t2 = tcolumn{
 retval.ret.AddToList($t2.ret);
 })*;


tcolumn returns[TableColumn ret]
@init
{
	retval.ret = new TableColumn();
} 
:(('primary key' | 'PRIMARY KEY'){
retval.ret.SetUniqueKey("PRIMARY KEY");
}
|('index'|'INDEX'){
retval.ret.SetUniqueKey("INDEX");
})? NAME type{
if($NAME.text == "<missing NAME>")
{		
	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Column Name.");
	throw qpe;
}
else
{	retval.ret.SetColumnName($NAME.text);
	retval.ret.SetVarType($type.ret);
}
};

type returns[VarType ret]
@init
{
retval.ret = new VarType();
}
:('char'|'CHAR'){retval.ret.SetVarType("CHAR");}
|('short'|'SHORT'){retval.ret.SetVarType("SHORT");}
|(' int'|' INT'){retval.ret.SetVarType("INT");}
|('long'|'LONG'){retval.ret.SetVarType("LONG");}
|('biglong'|'BIGLONG'){retval.ret.SetVarType("BIGLONG");}
|('float'|'FLOAT'){retval.ret.SetVarType("FLOAT");}
|('double'|'DOUBLE'){retval.ret.SetVarType("DOUBLE");}
| ('VARCHAR('n1=NUMBER{
if($n1.text=="<missing NUMBER>")
{
QueryParserException qpe = new QueryParserException("Error in parsing query: Missing VARCHAR Range.");
	throw qpe;
}
else{
retval.ret.SetVarRange($n1.text);}
}')'| 'varchar('n2=NUMBER{
if($n2.text=="<missing NUMBER>")
{
QueryParserException qpe = new QueryParserException("Error in parsing query: Missing VARCHAR Range.");
	throw qpe;
}
else
{
retval.ret.SetVarRange($n2.text);
}
} 
')'){
retval.ret.SetVarType("VARCHAR");
}; 


mod_table returns[ModifyTab ret]
@init
{
retval.ret = new ModifyTab();
retval.ret.SetStatementType(StatementType.MOD_TABLE);
}
:delete_column 
{
retval.ret.SetType("DELETE");
retval.ret.SetDelColumnData($delete_column.ret);
}
| add_column 
{
retval.ret.SetType("ADD");
retval.ret.SetAddColumnData($add_column.ret);
};

delete_column returns[DeleteColumn ret] 
@init
{
retval.ret = new DeleteColumn();

}
:('delete '|'DELETE ')('column '|'COLUMN ')NAME(' in '|' IN ')('table '|'TABLE ') table_name';'{
if($NAME.text == "<missing NAME>")
{		
	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Column Name.");
	throw qpe;
}
else
{							
retval.ret.SetColumnData($NAME.text);
retval.ret.SetTableName($table_name.ret.GetTableName());
}
};


add_column returns[AddColumn ret] 
@init
{
retval.ret = new AddColumn();
}
:('add '|'ADD ')('column '|'COLUMN ')tcolumn{retval.ret.SetColumnData($tcolumn.ret);}(' in '|' IN ')('table '|'TABLE ') table_name';'{							
retval.ret.SetTableName($table_name.ret.GetTableName());
};


table_name returns[Table ret]
@init 
{
	retval.ret = new Table();
} 
: Name1=NAME'.'Name3=NAME  
{
if($Name1.text == "<missing NAME>" || $Name2.text == "<missing NAME>")
{		
QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Table Name.");
throw qpe;
}
else			
retval.ret.SetTableName($Name1.text+"."+$Name3.text); }
| Name2=NAME {
if($Name2.text == "<missing NAME>")
{		
QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Table Name.");
throw qpe;
}
else						
retval.ret.SetTableName($Name2.text); 
};


create_db returns [CreateDB ret]
@init
{
	retval.ret = new CreateDB();
	retval.ret.SetStatementType(StatementType.CREATE_DB);
}
:('create db '|'CREATE DB ')NAME';'{
if($NAME.text == "<missing NAME>")
{		
QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Database Name.");
throw qpe;
}
else
retval.ret.SetDatabaseName($NAME.text);
};


select_db returns [SelectDB ret]
@init
{
	retval.ret = new SelectDB();
	retval.ret.SetStatementType(StatementType.SELECT_DB);
}
: ('select db '|'SELECT DB ')NAME';'{
if($NAME.text == "<missing NAME>")
{		
QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Database Name.");
throw qpe;
}
else
retval.ret.SetDatabaseName($NAME.text);
};


delete_db returns [DeleteDB ret]
@init
{
	retval.ret = new DeleteDB();
	retval.ret.SetStatementType(StatementType.DELETE_DB);
}
:('delete db '|'DELETE DB ')NAME';'{
if($NAME.text == "<missing NAME>")
{		
QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Database Name.");
throw qpe;
}
else
retval.ret.SetDatabaseName($NAME.text);
};


delete_table returns [DeleteTable ret]
@init
{
	retval.ret = new DeleteTable();
	retval.ret.SetStatementType(StatementType.DELETE_TABLE);
}
:('delete table '|'DELETE TABLE ')table_name';'{
retval.ret.SetTableName($table_name.ret.GetTableName());
};


empty_table returns [EmptyTable ret]
@init
{
	retval.ret = new EmptyTable();
	retval.ret.SetStatementType(StatementType.EMPTY_TABLE);
}
:('empty table ' | 'EMPTY TABLE ')table_name';'{

retval.ret.SetTableName($table_name.ret.GetTableName());
};

select_rows returns [SelectRows ret]
@init
{
	retval.ret = new SelectRows();
	retval.ret.SetStatementType(StatementType.SELECT_ROW);
}
:('select ' | 'SELECT ')select_row_table_column_list { retval.ret.SetSelectRowTableColList($select_row_table_column_list.ret); }
	(' from ' | ' FROM ') table_name { retval.ret.SetTableName($table_name.ret); }
	where_list? { retval.ret.SetWhereList($where_list.ret); if( retval.ret.GetWhereList() == null)
																retval.ret.SetWhereListFlag(false); 
															else 
																retval.ret.SetWhereListFlag(true); }
	order_by_list? { retval.ret.SetOrderByList($order_by_list.ret); 
															if( retval.ret.GetOrderByList() == null)
																retval.ret.SetOrderByFlag(false);
															else
																retval.ret.SetOrderByFlag(true); }
	limit_range? { retval.ret.SetLimitRange($limit_range.ret); 
															if( retval.ret.GetLimitRange() == null)
																retval.ret.SetLimitRangeFlag(false);
															else
																retval.ret.SetLimitRangeFlag(true);}
	';';

select_row_table_column_list returns [SelectRowTableColList ret]
@init
{
	retval.ret = new SelectRowTableColList(); 
} 
:'*' { retval.ret.SetSelectRowsColumnType(SelectRowColumnType.ALL_COLUMNS);} 
	| col_list { retval.ret.SetSelectRowsColumnType(SelectRowColumnType.SPECIFIC_COLUMNS); retval.ret.SetTableColumnList($col_list.ret);} 
	| count_rows { retval.ret.SetSelectRowsColumnType(SelectRowColumnType.COUNT_ROWS); retval.ret.SetCountRows($count_rows.ret);} ;

col_list returns [SelectColumnList ret]
@init
{
       retval.ret = new SelectColumnList();
}
: t1 = NAME {retval.ret.AddToList($t1.text);} (', ' t2 = NAME {retval.ret.AddToList($t2.text);} )*;


where_list returns [WhereList ret]
@init
{
	retval.ret = new WhereList();
}
:(' WHERE ' | ' where ') sub_where_list { retval.ret.SetSubWhereList($sub_where_list.ret);};

sub_where_list returns [SubWhereList ret]
@init
{
	retval.ret = new SubWhereList();
}
: we1 = where_entry { retval.ret.AddWhereEntryList($we1.ret);} 
	((' and ' | ' AND ') we2 = where_entry { retval.ret.AddWhereEntryList($we2.ret);})*;

where_entry returns [WhereEntry ret]
@init
{
	retval.ret = new WhereEntry();
}
:	NAME {retval.ret.SetColumnName($NAME.text);} 
	('=' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.EQUALITY);}
	|'<' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.LESS_THAN);}
	|'>' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.GREATER_THAN);}
	|'<=' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.LESS_THAN_EQUAL);}
	|'>=' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.GREATER_THAN_EQUAL);}
	|' = ' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.EQUALITY);}
	|' < ' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.LESS_THAN);}
	|' > ' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.GREATER_THAN);}
	|' <= ' { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.LESS_THAN_EQUAL);}
	|' >= ') { retval.ret.SetComparisonOperatorType(ComparisonOperatorType.GREATER_THAN_EQUAL);}
	column_value {retval.ret.SetColumnValue($column_value.ret);};

column_value returns [ColumnValue ret]
@init
{
	retval.ret = new ColumnValue();
} 
: NUMBER { retval.ret.SetColumnValueType(ColValueType.INTEGER); retval.ret.SetIntColumnValue($NUMBER.text); } 
	|NAME { retval.ret.SetColumnValueType(ColValueType.STRING); retval.ret.SetStringColumnValue($NAME.text); }
	|(t1 = NUMBER '.' t2 = NUMBER) { retval.ret.SetColumnValueType(ColValueType.DOUBLE); retval.ret.SetDoubleColumnValue($t1.text + "." + $t2.text); }; 

order_by_list returns [OrderByList ret]
@init
{
	retval.ret = new OrderByList();
}
:(' order by ' | ' ORDER BY ') sub_order_by_list { retval.ret.SetSubOrderByList($sub_order_by_list.ret);};

sub_order_by_list returns [SubOrderByList ret]
@init
{
	retval.ret = new SubOrderByList();
}
: obe1 = order_by_entry { retval.ret.AddOrderByEntryList($obe1.ret);} 
	((', ') obe2 = order_by_entry { retval.ret.AddOrderByEntryList($obe2.ret);})*;

order_by_entry returns [OrderByEntry ret]
@init
{
	retval.ret = new OrderByEntry();
}
:NAME { retval.ret.SetColumnName($NAME.text); } ((' asc'|' ASC') { retval.ret.SetOrderByType("ASC");} |(' dsc'|' DSC') { retval.ret.SetOrderByType("DSC");}); 
									

limit_range returns [LimitRange ret]
@init
{
	retval.ret = new LimitRange();
}
:('LIMIT' | 'limit') n1 = NUMBER { retval.ret.SetStartIndex($n1.text); }' , ' n2 = NUMBER { retval.ret.SetCount($n2.text);}; 

count_rows returns [CountRows ret]
@init
{
	retval.ret =  new CountRows();
}
:('COUNT(' | 'count(') ( NAME { retval.ret.SetColumnName($NAME.text); retval.ret.SetCountAllRowsFlag(false); } 
						| '*' { retval.ret.SetCountAllRowsFlag(true);}) ')'; 


update_row returns [UpdateRows ret]
@init
{
	retval.ret = new UpdateRows();
	retval.ret.SetStatementType(StatementType.UPDATE_ROW);
	retval.ret.SetWhereListFlag(false);
}
: ( 'UPDATE' | 'update' ) table_name { retval.ret.SetTableName($table_name.ret);} 
  ( 'SET' | 'set' ) set_list { retval.ret.SetSetList($set_list.ret); } 
  where_list? { retval.ret.SetWhereList($where_list.ret); retval.ret.SetWhereListFlag(true);}';';

set_list returns [SetList ret]
@init
{
	retval.ret = new SetList();
} 
: se1 = set_entry { retval.ret.AddSetEntryList($se1.ret);} (( 'AND' | 'and' ) se2 = set_entry { retval.ret.AddSetEntryList($se2.ret);} )*;

set_entry returns [SetEntry ret]
@init
{
	retval.ret = new SetEntry();
}
: NAME { retval.ret.SetColumnName($NAME.text); } ('='|' = ') column_value { retval.ret.SetColumnValue($column_value.ret);}; 

delete_row returns [DeleteRows ret]
@init
{
	retval.ret = new DeleteRows();
	retval.ret.SetStatementType(StatementType.DELETE_ROWS);
	retval.ret.SetWhereListFlag(false);
}
: ('delete' | 'DELETE' ) ( 'from' | 'FROM' ) table_name { retval.ret.SetTableName($table_name.ret);} where_list? { retval.ret.SetWhereList($where_list.ret); retval.ret.SetWhereListFlag(true);};

insert_row returns [InsertRow ret]
@init
{
retval.ret = new InsertRow();
retval.ret.SetStatementType(StatementType.INSERT_ROW);
}
:('insert into'|'INSERT INTO')table_name{
retval.ret.SetTableName($table_name.ret.GetTableName());
}
'(' table_column_list{
retval.ret.SetList($table_column_list.ret.GetColumnList());
}
')' ('values'|'VALUES') '(' column_value_list{
retval.ret.SetValueList($column_value_list.ret.GetColumnValue());
}
');';



table_column_list returns[ColumnList_Ins ret]
@init
{
	retval.ret = new ColumnList_Ins();
}
:t1 = column_name{
retval.ret.AddToList($t1.ret.GetColumnName());
}
(',' t2 = column_name{
retval.ret.AddToList($t2.ret.GetColumnName());
})*;


column_name returns[ColumnName ret]
@init
{
	retval.ret = new ColumnName();
} 
:NAME{
if($NAME.text == "<missing NAME>")
{		
	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Column Name.");
	throw qpe;
}
else
{	retval.ret.SetColumnName($NAME.text);
}
};


column_value_list returns[ColumnValueList ret]
@init
{
retval.ret = new ColumnValueList();
}
:c1 = column_value{
retval.ret.SetColumnValue($c1.ret);
}
(',' c2 = column_value{
retval.ret.SetColumnValue($c2.ret);
})*;


rename_table returns [RenameTable ret]
@init
{
retval.ret = new RenameTable();
retval.ret.SetStatementType(StatementType.RENAME_TABLE);
}:('rename ' | 'RENAME ')('table '|'TABLE ')n1 = table_name ' TO ' n2 = table_name';'
{
retval.ret.SetOldTableName($n1.ret.GetTableName());
retval.ret.SetNewTableName($n2.ret.GetTableName());
};

rename_column returns [RenameColumn ret]
@init
{
retval.ret = new RenameColumn();
retval.ret.SetStatementType(StatementType.RENAME_COLUMN);
}:('rename ' | 'RENAME ')('column '|'COLUMN ')Name1 = NAME ' TO ' Name2 = NAME ' IN ' 'TABLE 'table_name';'
{
if($Name1.text == "<missing NAME>" || $Name2.text == "<missing NAME>")
{		
QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Column Name.");
throw qpe;
}
else
{
retval.ret.SetOldColumnName($Name1.text);
retval.ret.SetNewColumnName($Name2.text);
retval.ret.SetTableName($table_name.ret.GetTableName());
}
};
/* Lexer Rules*/									
NAME : ('a'..'z'|'A'..'Z')('a'..'z'|'A'..'Z'|'0'..'9')*;
NUMBER : ('0'..'9')('0'..'9')*;
WHITESPACE : (' ' | '\t' | '\n' | '\r' )+ {$channel = HIDDEN;};
