<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Criar Nova Agenda</title>
    </head>
    <body>
        <h1>Criar uma nova agenda</h1>
        <form action="salvar.jsp" name="formCadastro" method="post">
            <label>Descrição</label>
            <input type="text" name="descricao" id="fdescricao" value=""> <br>
            <label>Data</label>
            <input type="text" name="data" id="fdata" value=""> <br>
            <label>Membro Responsável</label>
            <input type="text" name="responsavel" id="fresponsavel" value=""> <br>
            <label>Local</label>
            <input type="text" name="local" id="flocal" value=""> <br><br>
            <input type="reset" name="limpar" value="Limpar">
            <input type="submit" name="salvar" value="Salvar">
        </form>
    </body>
</html>