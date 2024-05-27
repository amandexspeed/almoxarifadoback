USE xAlmoxarifado

GO
CREATE PROCEDURE spBuscaItensNota(@idNota int)
AS
SELECT p.DESCRICAO, itn.QTD_PRO 
FROM ITENS_NOTA itn
INNER JOIN NOTA_FISCAL n on n.ID_NOTA = @idNota and n.ID_NOTA = itn.ID_NOTA
INNER JOIN PRODUTO p on p.ID_PRO = itn.ID_PRO

GO
CREATE PROCEDURE spBuscaEstoqueItensNota(@idNota int) 
AS
SELECT p.ID_PRO,p.DESCRICAO,e.QTD_PRO
FROM ITENS_NOTA itn
INNER JOIN NOTA_FISCAL n on n.ID_NOTA = @idNota and n.ID_NOTA = itn.ID_NOTA
INNER JOIN PRODUTO p on p.ID_PRO = itn.ID_PRO
INNER JOIN ESTOQUE e on p.ID_PRO = E.ID_PRO

GO
CREATE PROCEDURE spBuscaItensRequisicao(@idRequisicao int)
AS
SELECT p.DESCRICAO, itr.QTD_PRO 
FROM ITENS_REQ itr
INNER JOIN REQUISICAO r on r.ID_REQ = @idRequisicao and r.ID_REQ = itr.ID_REQ
INNER JOIN PRODUTO p on p.ID_PRO = itr.ID_PRO

GO
CREATE PROCEDURE spBuscaEstoqueItensRequisicao(@idRequisicao int) 
AS
SELECT p.ID_PRO,p.DESCRICAO,e.QTD_PRO
FROM ITENS_REQ itr
INNER JOIN REQUISICAO r on r.ID_REQ = @idRequisicao and r.ID_REQ = itr.ID_REQ
INNER JOIN PRODUTO p on p.ID_PRO = itr.ID_PRO
INNER JOIN ESTOQUE e on p.ID_PRO = E.ID_PRO


GO
CREATE PROCEDURE spBuscaAbaixoEstoqueMinimo(@idNota int)
AS
SELECT p.ID_PRO,p.DESCRICAO,e.QTD_PRO,p.ESTOQUE_MIN
FROM ITENS_NOTA itn
INNER JOIN NOTA_FISCAL n on n.ID_NOTA = @idNota and n.ID_NOTA = itn.ID_NOTA
INNER JOIN PRODUTO p on p.ID_PRO = itn.ID_PRO
INNER JOIN ESTOQUE e on p.ID_PRO = E.ID_PRO
WHERE p.ESTOQUE_MIN < e.QTD_PRO



GO
CREATE PROCEDURE spAtualizaEstoque(@idProduto int, @quantidade numeric)
AS
UPDATE ESTOQUE 
SET QTD_PRO = @quantidade
WHERE ID_PRO = @idProduto


GO
CREATE PROCEDURE spExcluirNota(@idNota int)
AS
BEGIN

	CREATE TABLE #RegistrosSelecionadosTemp (
		idProduto INT,
		Quantidade int
	);

	INSERT INTO #RegistrosSelecionadosTemp
	SELECT p.ID_PRO, itn.QTD_PRO FROM PRODUTO p 
	INNER JOIN ITENS_NOTA itn on p.ID_PRO = itn.ID_PRO and itn.ID_NOTA = @idNota

	UPDATE E
	SET QTD_PRO = R.Quantidade + QTD_PRO
	FROM ESTOQUE AS E
	INNER JOIN #RegistrosSelecionadosTemp AS R ON R.idProduto = ID_PRO

END

GO
CREATE PROCEDURE spExcluirRequisicao(@idRequisicao int)
AS
BEGIN

	CREATE TABLE #RegistrosSelecionadosTemp (
		idProduto INT,
		Quantidade int
	);

	INSERT INTO #RegistrosSelecionadosTemp
	SELECT p.ID_PRO, itr.QTD_PRO FROM PRODUTO p 
	INNER JOIN ITENS_REQ itr on p.ID_PRO = itr.ID_PRO and itr.ID_REQ = @idRequisicao

	UPDATE E
	SET QTD_PRO = R.Quantidade + QTD_PRO
	FROM ESTOQUE AS E
	INNER JOIN #RegistrosSelecionadosTemp AS R ON R.idProduto = ID_PRO

END

GO
CREATE TRIGGER trExcluirNota
ON NOTA_FISCAL
INSTEAD OF DELETE
NOT FOR REPLICATION
AS
BEGIN

	DECLARE @ID int
	SELECT @ID = ID_NOTA FROM deleted

	EXEC spExcluirNota @idNota = @ID;

	DELETE FROM ITENS_NOTA
	WHERE ID_NOTA = @ID

	DELETE FROM NOTA_FISCAL
	WHERE ID_NOTA = @ID

END

GO
CREATE TRIGGER trExcluirRequisicao
ON REQUISICAO
INSTEAD OF DELETE
NOT FOR REPLICATION
AS
BEGIN

	DECLARE @ID int
	SELECT @ID = ID_REQ FROM deleted

	EXEC spExcluirRequisicao @idRequisicao = @ID;

	DELETE FROM ITENS_REQ
	WHERE ID_REQ= @ID

	DELETE FROM REQUISICAO
	WHERE ID_REQ = @ID

END









