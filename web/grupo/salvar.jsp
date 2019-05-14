<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="dominio.Grupo"%>
<%@page import="persistencia.GrupoBD"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastro de Grupo</title>
    </head>
    <body>
        <%
            String descricao = request.getParameter("descricao");

            Grupo grupo = new Grupo();

            grupo.setDescricao(descricao);

            GrupoBD.inserir(grupo);
        %>

        <br>

        <!-- Teste de impressão na tela -->
        Descrição: <%=descricao%> <br>

        <p>Grupo cadastrado com sucesso!!!</p>
        <a href="../index.xhtml">Voltar</a>
    </body>
</html>