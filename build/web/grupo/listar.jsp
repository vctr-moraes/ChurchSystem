<%@page import="dominio.Grupo"%>
<%@page import="java.util.ArrayList"%>
<%@page import="persistencia.GrupoBD"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Lista de Grupos</title>
    </head>
    <body>
        <h1>Lista de grupos</h1>

        <%
            ArrayList<Grupo> grupos = GrupoBD.listar();

            for (int i = 0; i < grupos.size(); i++) {
                Grupo cadaGrupo = grupos.get(i);
                out.println(cadaGrupo.getDescricao());
        %>
        <a href="excluir.jsp?codigo=<%=cadaGrupo.getCodigo()%>" onclick="return confirm('Deseja realmente excluir?')">Excluir</a>
        <%
            }
        %>
    </body>
</html>