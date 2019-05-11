<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.util.Date"%>
<%@page import="java.text.SimpleDateFormat"%>
<%@page import="dominio.Agenda"%>
<%@page import="persistencia.AgendaBD"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cadastrar Nova Agenda</title>
    </head>
    <body>
        <%
            String descricao = request.getParameter("descricao");
            String dataAgenda = request.getParameter("data");
            String responsavel = request.getParameter("responsavel");
            String local = request.getParameter("local");
            
            SimpleDateFormat formato = new SimpleDateFormat("dd/MM/yyyy");
            Date data = formato.parse(responsavel);
            
            //Converter uma string com o nome do Responsável para o objeto Responsavel
            
            Agenda agenda = new Agenda();
            
            agenda.setDescricao(descricao);
            agenda.setData(data);
            //agenda.setMembro(responsavel);
            agenda.setLocal(local);
        %>
    </body>
</html>
