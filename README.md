* was created console application connecting to the sql server
* was created filter-repo branch which contains basic func delegate taking LOGS type (queries only those containing EAKGUL in the URL property) data and returning bool type data => Func<LOGS,bool>
* was created filter-repo-2 branch which contains basic func delegate taking LOGS type (queries containing url and createdate properies) data and returning bool type data  => Func<LOGS,bool>
* was created filter-order branch which contains parameter that ordering query func => Func<IQueryable<LOGS>,IOrderedQueryable<LOGS>>
* was created filter-order-skip-take branch  which contains parameter that skipping and taking on collection data
* was created filter-expression branch which contains Expression<Func<LOGS,bool>> delegate function
* 
