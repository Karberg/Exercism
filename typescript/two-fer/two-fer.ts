export function twoFer(name?: string): string {
  if (name != null) {
    return 'One for ${name}, one for me.';
  }
  return 'One for you, one for me.';

}
