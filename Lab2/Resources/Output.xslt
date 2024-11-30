<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<!-- Визначення шаблону -->
	<xsl:template match="/">
		<html>
			<head>
				<title>Catalog of Books</title>
				<style>
					table {
						border-collapse: collapse;
						width: 100%;
					}
					th, td {
						border: 1px solid black;
						padding: 8px;
						text-align: left;
					}
					th {
						background-color: #f2f2f2;
					}
				</style>
			</head>
			<body>
				<h1>Book Catalog</h1>
				<table>
					<thead>
						<tr>
							<th>ID</th>
							<th>Title</th>
							<th>Genre</th>
							<th>Author</th>
							<th>Publisher</th>
							<th>Price</th>
							<th>Description</th>
						</tr>
					</thead>
					<tbody>
						<!-- Перебір кожної книги -->
						<xsl:for-each select="catalog/book">
							<tr>
								<td>
									<xsl:value-of select="@id"/>
								</td>
								<td>
									<xsl:value-of select="title"/>
								</td>
								<td>
									<xsl:value-of select="@genre"/>
								</td>
								<td>
									<xsl:value-of select="@author"/>
								</td>
								<td>
									<xsl:choose>
										<xsl:when test="@publisher">
											<xsl:value-of select="@publisher"/>
										</xsl:when>
										<xsl:otherwise>No publisher</xsl:otherwise>
									</xsl:choose>
								</td>
								<td>
									<xsl:value-of select="price"/>
								</td>
								<td>
									<xsl:value-of select="description"/>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
