export function getGreetingTime(hours? : number) {
    let date = new Date();
    let hrs = hours || date.getHours();
    let strGreet = '';

    if (hrs < 12)
        strGreet = 'good morning';
    else if (hrs >= 12 && hrs <= 17)
        strGreet = 'good afternoon';
    else if (hrs >= 17 && hrs <= 20)
        strGreet = 'good evening';
    else if (hrs >= 20 && hrs <= 24)
        strGreet = 'good night';
    else 
        strGreet = 'good day'
  
    return strGreet;
}

export function getTimestamp() {
    return new Date();
}