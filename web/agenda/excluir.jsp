<%@page import="persistencia.AgendaBD"%>

<%
    String codigo = request.getParameter("codigo");
    
    int cod;
    cod = Integer.parseInt(codigo);
    
    AgendaBD.excluir(cod);
    
    response.sendRedirect("agenda.jsp");
%>