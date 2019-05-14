<%@page import="persistencia.DoacaoBD"%>
<%@page import="java.util.ArrayList"%>
<%@page import="dominio.Doacao"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Lista de Doações</title>
    </head>
    <body>
        <h1>Lista de doações</h1>

        <%
            ArrayList<Doacao> doacoes = DoacaoBD.listar();

            for (int i = 0; i < doacoes.size(); i++) {
                Doacao cadaDoacao = doacoes.get(i);
                out.println(cadaDoacao.getCodigo());
                out.println(cadaDoacao.getData());
                out.println(cadaDoacao.getMembro());
                out.println(cadaDoacao.getQuantia());
        %>
        <a href="excluir.jsp?codigo=<%=cadaDoacao.getCodigo()%>" onclick="return confirm('Deseja realmente excluir?')">Excluir</a>
        <%
            }
        %>
    </body>
</html>
