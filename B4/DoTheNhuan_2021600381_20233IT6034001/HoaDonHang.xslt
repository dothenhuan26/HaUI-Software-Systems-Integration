<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/DS">
		<html>
			<head>
				<title>Hoa Don Hang</title>
			</head>

			<body>
				<h1>Hoa Don Hang</h1>

				<xsl:for-each select="HoaDon">
					<table border="0">
						<tr>
							<td>
								Hóa đơn: <xsl:value-of select="MaHD" />
							</td>
						</tr>
						<tr>
							<td>
								Ngày bán: <xsl:value-of select="NgayBan" />
							</td>
						</tr>
						<tr>
							<td>
								Ngày bán: <xsl:value-of select="LoaiHang/@TenLoai" />
							</td>
						</tr>
					</table>
					<table border="2" cellpadding="3">
						<tr>
							<td>Mã Hàng</td>
							<td>Tên Hàng</td>
							<td>Số Lượng</td>
							<td>Đơn Gía</td>
							<td>Thành Tiền</td>
						</tr>
						<xsl:for-each select="LoaiHang/Hang">
							<tr>
								<td>
									<xsl:value-of select="@MaHang"/>
								</td>
								<td>
									<xsl:value-of select="TenHang"/>
								</td>
								<td>
									<xsl:value-of select="SoLuong"/>
								</td>
								<td>
									<xsl:value-of select="DonGia"/>
								</td>
								<td>
									<xsl:value-of select="DonGia*SoLuong"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</xsl:for-each>
			</body>

		</html>
	</xsl:template>
</xsl:stylesheet>
