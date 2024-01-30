<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
				xmlns:x="http://tempuri.org/nhanvien.xsd"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Bang Luong</title>
			</head>
			<body>

				<h1 align="center">BẢNG LƯƠNG THÁNG</h1>
				<xsl:for-each select="x:DS/x:congty">
					<div>
						<h2>
							Tên công ty: <xsl:value-of select="@TenCT"/>
						</h2>
						<xsl:for-each select="x:donvi">
							<h2>
								Tên phòng: <xsl:value-of select="x:tendv"/>
							</h2>

							<table border="1" width="100%">
								<thead>
									<tr>
										<th>STT</th>
										<th>Họ tên</th>
										<th>Ngày sinh</th>
										<th>Ngày công</th>
										<th>Lương</th>
									</tr>
								</thead>
								<tbody>
									<xsl:for-each select="x:nhanvien">
										<tr>
											<td>
												<xsl:value-of select="position()"/>
											</td>
											<td>
												<xsl:value-of select="x:hoten"/>
											</td>
											<td>
												<xsl:value-of select="x:ngaysinh"/>
											</td>
											<td>
												<xsl:value-of select="x:ngaycong"/>
											</td>
											<td>
												<xsl:choose>
													<xsl:when test="x:ngaycong&gt;25">
														<xsl:value-of select="20*150000+5*200000+(number(x:ngaycong)-25)*250000"/>
													</xsl:when>
													<xsl:when test="x:ngaycong&lt;20">
														<xsl:value-of select="x:ngaycong*150000"/>
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="20*150000+(number(x:ngaycong)-20)*200000"/>
													</xsl:otherwise>
												</xsl:choose>
											</td>
										</tr>
									</xsl:for-each>

								</tbody>
							</table>

						</xsl:for-each>


					</div>

				</xsl:for-each>



			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
