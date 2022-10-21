import { getGreetingTime, getTimestamp} from '@functions/helpers/datetime';

it('should return a string with the a Good Greet message', async () => {
    let greetMsg = getGreetingTime()
    expect( greetMsg ).toBeTruthy()
    expect( greetMsg ).toEqual(expect.any(String))
    expect( greetMsg ).not.toEqual("not good day")
})

it('should return a string with the a good morning message', async () => {
    let greetMsg = getGreetingTime(10)
    expect( greetMsg ).toEqual("good morning")
})

it('should return a string with the a good afternoon message', async () => {
    let greetMsg = getGreetingTime(14)
    expect( greetMsg ).toEqual("good afternoon")
})

it('should return a string with the a good evening message', async () => {
    let greetMsg = getGreetingTime(18)
    expect( greetMsg ).toEqual("good evening")
})

it('should return a string with the a good night message', async () => {
    let greetMsg = getGreetingTime(21)
    expect( greetMsg ).toEqual("good night")
})

it('should return a string with the a good day message', async () => {
    let greetMsg = getGreetingTime(99)
    expect( greetMsg ).toEqual("good day")
})


it('should return a dateTimeStamp', async () => {
    let dateStr = getTimestamp()
    expect( dateStr ).toBeTruthy()
})