SELECT
max(c.id)
--CASE 
--WHEN ((d.kind+d.check_item) LIKE N'%ピーリング%' or (d.kind+d.check_item) LIKE N'%平面引张%') THEN N'ピーリング（平面引张）'
--WHEN (d.kind+d.check_item) LIKE N'%クリープ%' THEN N'クリープ'
--WHEN (d.kind+d.check_item) LIKE N'%寸法%' THEN N'寸法'
--WHEN (d.kind+d.check_item) LIKE N'%材破%' THEN N'材破'
--WHEN (d.kind+d.check_item) LIKE N'%ピーリング%' THEN N'ピーリング'
--WHEN (d.kind+d.check_item) LIKE N'%螺钉螺母%' THEN N'螺钉螺母'
--ELSE
--''
--END KM
,1 N'总数'
,MAX(CASE WHEN ((d.kind+d.check_item) LIKE N'%ピーリング%' or (d.kind+d.check_item) LIKE N'%平面引张%') AND a.result<>'OK' THEN 1 ELSE 0 END) N'ピーリング（平面引张）NG'
,MAX(CASE WHEN (d.kind+d.check_item) LIKE N'%クリープ%' AND a.result<>'OK' THEN 1 ELSE 0 END)  N'クリープNG'
,MAX(CASE WHEN (d.kind+d.check_item) LIKE N'%寸法%' AND a.result<>'OK' THEN 1 ELSE 0 END)  N'寸法NG'
,MAX(CASE WHEN (d.kind+d.check_item) LIKE N'%材破%' AND a.result<>'OK' THEN 1 ELSE 0 END)  N'材破NG'
,MAX(CASE WHEN (d.kind+d.check_item) LIKE N'%ピーリング%' AND a.result<>'OK' THEN 1 ELSE 0 END)  N'ピーリングNG'
,MAX(CASE WHEN (d.kind+d.check_item) LIKE N'%螺钉螺母%' AND a.result<>'OK' THEN 1 ELSE 0 END)  N'螺钉螺母NG'

--,SUM(CASE WHEN a.result<>'OK' THEN 1 ELSE 0 END) NG_SUU

FROM   t_result_detail a
       LEFT JOIN t_dlx_chk b
              ON a.result_id = b.id
       LEFT JOIN t_check_result c
              ON a.result_id = c.id
       LEFT JOIN m_check d
              ON d.id = a.check_id
WHERE c.id > '2021120100034' 

GROUP BY
c.id

--, CASE 
--WHEN ((d.kind+d.check_item) LIKE N'%ピーリング%' or (d.kind+d.check_item) LIKE N'%平面引张%') THEN N'ピーリング（平面引张）'
--WHEN (d.kind+d.check_item) LIKE N'%クリープ%' THEN N'クリープ'
--WHEN (d.kind+d.check_item) LIKE N'%寸法%' THEN N'寸法'
--WHEN (d.kind+d.check_item) LIKE N'%材破%' THEN N'材破'
--WHEN (d.kind+d.check_item) LIKE N'%ピーリング%' THEN N'ピーリング'
--WHEN (d.kind+d.check_item) LIKE N'%螺钉螺母%' THEN N'螺钉螺母'
--ELSE
--''
--END