<%@page import="persistencia.MembroBD"%>

<%
    String matricula = request.getParameter("matricula");

    int matriculaInt;
    matriculaInt = Integer.parseInt(matricula);

    MembroBD.excluir(matriculaInt);

    response.sendRedirect("membro.jsp");
%>