
function MascaraAsteriscosMail(mail) {

    let value = mail;;
    let chars = 3; // Cantidad de caracters visibles

    let res = value.replace(/[a-z0-9\-_.]+@/ig, (c) => c.substr(0, chars) + c.split('').slice(chars, -1).map(v => '*').join('') + '@')
    
    return res
    
}