<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
				xmlns:x="http://tempuri.org/congty.xsd"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<title>Cong Ty</title>

				<style>
					.heading {
					font-weight: bold;
					color: blue;
					font-size: 25px;
					background: red;
					}
					.pos {
					text-align: right;
					}
					.str {
					text-align: center;
					}
				</style>

			</head>
			<body>
				<h1 align="center">BẢNG LƯƠNG THÁNG 11-2020</h1>
				<xsl:for-each select="x:congty/x:donvi">
					<div>
						<p>
							Mã đơn vị: <xsl:value-of select="@madv" />
						</p>
						<p>
							Tên đơn vị: <xsl:value-of select="x:tendv" />
						</p>
						<p>
							Điện thoại: <xsl:value-of select="x:dienthoai" />
						</p>

						<h2 align="center">DANH SÁCH NHÂN VIÊN</h2>
						<table border="1" width="100%" cellspacing="0">
							<thead>
								<tr class="heading">
									<th>SỐ TT</th>
									<th>MÃ NV</th>
									<th>HỌ TÊN</th>
									<th>NGÀY SINH</th>
									<th>HS LƯƠNG</th>
									<th>LƯƠNG</th>
								</tr>
							</thead>
							<tbody>
								<xsl:apply-templates select="x:nhanvien"></xsl:apply-templates>
								<!--<xsl:for-each select="x:nhanvien">
									<xsl:if test="x:hsluong>=3">
										<tr>
											<td class="pos">
												<xsl:value-of select="position()" />
											</td>
											<td class="str">
												<xsl:value-of select="x:manv"/>
											</td>
											<td class="str">
												<xsl:value-of select="x:hoten"/>
											</td>
											<td class="str">
												<xsl:value-of select="x:ngaysinh"/>
											</td>
											<td class="str">
												<xsl:value-of select="x:gioitinh"/>
											</td>
											<td class="str">
												<xsl:value-of select="x:hsluong"/>
											</td>
										</tr>
									</xsl:if>
								</xsl:for-each>-->
							</tbody>
						</table>
					</div>
					<center>--------------------------------------------------------------</center>
				</xsl:for-each>


			</body>
		</html>
	</xsl:template>

	<xsl:template match="x:nhanvien">
		<tr>
			<td class="pos">
				<xsl:value-of select="position()" />
			</td>
			<td class="str">
				<xsl:value-of select="x:manv"/>
			</td>
			<td class="str">
				<xsl:value-of select="x:hoten"/>
			</td>
			<td class="str">
				<xsl:value-of select="x:ngaysinh"/>
			</td>
			<td class="str">
				<xsl:value-of select="x:gioitinh"/>
			</td>
			<td class="str">
				<xsl:value-of select="x:hsluong"/>
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>
