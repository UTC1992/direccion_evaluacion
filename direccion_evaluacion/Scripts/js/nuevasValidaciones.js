jQuery.validator.addMethod("lettersonly", function(value, element) {
		  //return this.optional(element) || /^[a-z]+$/i.test(value);
		  return this.optional(element) || /^[A-Za-zÁÉÍÑÓÚáé íñó]*$/.test(value);
		 
		}, "Este campo solo acepta letras"); 

jQuery.validator.addMethod("numbersonly", function(value, element) {
	  //return this.optional(element) || /^[a-z]+$/i.test(value);
	  return this.optional(element) || /[0-9]/.test(value);
	 
	}, "Este campo solo acepta números"); 


jQuery.validator.addMethod('filesize', function(value, element, param) {
    // param = size (en bytes) 
    // element = element to validate (<input>)
    // value = value of the element (file name)
    return this.optional(element) || (element.files[0].size <= param) 
});



jQuery.validator.addMethod('positivo', function(value, element, param) {
    return value>=0;
},"El valor ingresado no puede ser negativo");



jQuery.validator.addMethod("ruc",function(value,element){
		//1721895181001
	  var digitosFinales=value.substring(10, 13);
	  
	  if(digitosFinales=="001"){
		  
		  var cedula =value.substring(0, 10);
		  //alert(cedula);
		  array = cedula.split( "" );
		  num = array.length;
		  if ( num == 10 )
		  {
		    total = 0;
		    digito = (array[9]*1);
		    for( i=0; i < (num-1); i++ )
		    {
		      mult = 0;
		      if ( ( i%2 ) != 0 ) {
		        total = total + ( array[i] * 1 );
		      }
		      else
		      {
		        mult = array[i] * 2;
		        if ( mult > 9 )
		          total = total + ( mult - 9 );
		        else
		          total = total + mult;
		      }
		    }
		    decena = total / 10;
		    decena = Math.floor( decena );
		    decena = ( decena + 1 ) * 10;
		    final = ( decena - total );
		    if ( ( final == 10 && digito == 0 ) || ( final == digito ) ) {
		     // alert( "La c\xe9dula ES v\xe1lida!!!" );
		      return true;
		    }
		    else{
		    	return false;
		    }
	    }
	    else
	    {
	      //alert( "La c\xe9dula NO es v\xe1lida!!!" );
	      return false;
	    }
	  }
	  else
	  {
	    //alert("La c\xe9dula no puede tener menos de 10 d\xedgitos");
	    return false;
	  }
	
}, "Cedula Incorrecta");






//validacion de cedula para el personal dentro de Usuario ....cedula1


jQuery.validator.addMethod("cedula",function(value,element){

	  
	  if(true){
		  
		  var cedula =value;                       
		  //alert(cedula);
		  array = cedula.split( "" );
		  num = array.length;
		  if ( num == 10 )
		  {
		    total = 0;
		    digito = (array[9]*1);
		    for( i=0; i < (num-1); i++ )
		    {
		      mult = 0;
		      if ( ( i%2 ) != 0 ) {
		        total = total + ( array[i] * 1 );
		      }
		      else
		      {
		        mult = array[i] * 2;
		        if ( mult > 9 )
		          total = total + ( mult - 9 );
		        else
		          total = total + mult;
		      }
		    }
		    decena = total / 10;
		    decena = Math.floor( decena );
		    decena = ( decena + 1 ) * 10;
		    final = ( decena - total );
		    if ( ( final == 10 && digito == 0 ) || ( final == digito ) ) {
		     // alert( "La c\xe9dula ES v\xe1lida!!!" );
		      return true;
		    }
		    else{
		    	return false;
		    }
	    }
	    else
	    {
	      //alert( "La c\xe9dula NO es v\xe1lida!!!" );
	      return false;
	    }
	  }
	  else
	  {
	    //alert("La c\xe9dula no puede tener menos de 10 d\xedgitos");
	    return false;
	  }
	
}, "Cedula Incorrecta");




jQuery.validator.addMethod("EmailUtc", function(value, element) {
  // allow any non-whitespace characters as the host part
  return this.optional( element ) || /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@+utc.edu.ec/.test( value );
}, 'El correo no pertenece a la Institucion. Ej:nombre.apellido2@utc.edu.ec');





jQuery.validator.addMethod("leters1", function(value, element) {
  return this.optional(element) || /^[a-zA-Z á é í ó ú Á É Í Ó Ú]*$/.test(value);
}, "Este campo solo acepta letras");