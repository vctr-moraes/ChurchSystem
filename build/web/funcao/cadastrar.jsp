<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastro de Função</title>
    </head>
    <body>
        <h1>Cadastrar uma função</h1>
        <form action="salvar.jsp" name="formCadastro" method="post">
            <label>Descrição</label>
            <input type="text" name="descricao" id="fdescricao" value=""> <br><br>
            <input type="reset" name="limpar" value="Limpar">
            <input type="submit" name="salvar" value="Salvar">
        </form>
    </body>
</html>
