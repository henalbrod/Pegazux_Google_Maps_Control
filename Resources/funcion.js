var guardarCambios = function() {

	var main = [
		{'NRODCTO':TRADENRODCTOField.getValue()}, 
		{'ORIGEN':TRADEORIGENField.getValue()}, 
		{'TIPODCTO':TRADETIPODCTOField.getValue()}, 
		{'FECHAING':TRADEFECHAINGField.getValue()}, 
		{'FECHA':TRADEFECHAField.getValue()}, 
		{'HORA':TRADEHORAField.getValue()}, 
		{'FECHA1':TRADEFECHA1Field.getValue()}, 
		{'NIT':TRADENITField.getValue()}, 
		{'NOMBRE':TRADENOMBREField.getValue()}, 
		{'NOMBRE1':TRADENOMBRE1Field.getValue()}, 
		{'BRUTO':TRADEBRUTOField.getValue()}, 
		{'IVABRUTO':TRADEIVABRUTOField.getValue()}, 
		{'DESCUENTO':TRADEDESCUENTOField.getValue()}, 
		{'Valor_Descuento':TRADEValor_DescuentoField.getValue()}, 
		{'Total':TRADETotalField.getValue()}, 
		{'NOTA':TRADENOTAField.getValue()}, 
		{'PASSWORDIN':TRADEPASSWORDINField.getValue()}
	];
	
	var details = []; 
	
	var valid = (getCookie('FormIsValid'));
	
	if(getCookie('FormHaveChanges') != 'true'){		
		Ext.Msg.show({title:'No hay cambios',msg:'El formulario aún no presenta cambios que deban ser guardados.',buttons: Ext.Msg.OK,icon: Ext.MessageBox.INFO});
		return;		
	}; 
	
	if(valid == true){
		Ext.net.DirectMethods.formularioDinamico.GuardarCambios(main,details,getCookie('FormState'),
			
			{success: function (result) { 				
					if(result == true){ 
						setCookie('FormHaveChanges','false'); 
					};          
					
					Ext.net.DirectMethods.formularioDinamico.GetTable('CargarCotizaciones','TRADE','',
							{success: function (result) {					
								#{GridCenterPanel}.getStore().loadData(result);
							}
						}
					);                                 
				}
			}
		); 
		
		var store = #{GridCenterPanel}.getStore(); 
		store.reload(store.lastOptions);
		#{GridCenterPanel}.getView.refresh();
		
	}else{
		Ext.Msg.show({title:'Formulario inválido',msg:'El formulario se encuentra mal diligenciado, por favor verifique que no falten campos obligatorios o que el formato de los valores es el correcto.',buttons: Ext.Msg.OK,icon: Ext.MessageBox.INFO});
	};
};