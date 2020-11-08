import { blockchainGobTemplatePage } from './app.po';

describe('blockchainGob App', function() {
  let page: blockchainGobTemplatePage;

  beforeEach(() => {
    page = new blockchainGobTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
