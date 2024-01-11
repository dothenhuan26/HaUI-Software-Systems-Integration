﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<body>
				<h2>Students</h2>
				<table border="1">
					<tr bgcolor="blue">
						<th>Rollno</th>
						<th>First Name</th>
						<th>Last Name</th>
						<th>Nick Name</th>
						<th>Marks</th>
					</tr>
					<xsl:for-each select="class/student">
							<tr>
								<td>
									<xsl:value-of select="@rollno" />
								</td>
								<td>
									<xsl:value-of select="firstname" />
								</td>
								<td>
									<xsl:value-of select="lastname" />
								</td>
								<td>
									<xsl:value-of select="nickname" />
								</td>
								<td>
									<xsl:value-of select="mark" />
								</td>
							</tr>
					</xsl:for-each>
				</table>
			<h3>Ket qua: <xsl:value-of select="sum(class/student/mark)"/>
		</h3>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
