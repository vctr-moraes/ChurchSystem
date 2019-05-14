<%@page import="persistencia.AgendaBD"%>
<%@page import="dominio.Agenda"%>
<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Agenda</title>
    </head>
    <body>
        <h1>Agenda</h1>
        
        <%
            ArrayList<Agenda> agendas = AgendaBD.listar();
            
            for(int i = 0; i < agendas.size(); i++){
                Agenda cadaAgenda = agendas.get(i);
                out.println(cadaAgenda.getData());
                out.println(cadaAgenda.getDescricao());
                out.println(cadaAgenda.getLocal());
                out.println(cadaAgenda.getMembro());
        %>
        <a href="excluir.jsp?codigo=<%=cadaAgenda.getCodigo()%>" onclick="return confirm('Deseja realmente excluir?')">Excluir</a>
        <%
            }
        %>
    </body>
</html>
