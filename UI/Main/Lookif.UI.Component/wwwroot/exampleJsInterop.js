// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(Message) {
  return prompt(Message, 'Type anything here');
}
