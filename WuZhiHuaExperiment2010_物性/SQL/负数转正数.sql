update m_check set benchmark_value3 = '-'+benchmark_value3
where 
isnull(benchmark_value3,'')<>'' and 
cast(isnull(benchmark_value3,0) as decimal(10,4))>0
