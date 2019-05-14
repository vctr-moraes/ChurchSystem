<%@page import="persistencia.GrupoBD"%>

<%
    String codigo = request.getParameter("codigo");
    
    int cod;
    cod = Integer.parseInt(codigo);
    
    GrupoBD.excluir(cod);
    
    response.sendRedirect("grupo.jsp");
%>