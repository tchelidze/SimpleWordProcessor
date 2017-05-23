using System;
using System.Linq;
using System.Windows.Forms;
using GeorgianLanguageClasses;
using RemoveStopWords;
using RemoveStopWords.Core;

namespace StopWords
{
    public partial class Form1 : Form
    {
        readonly DelimiterProcessor _delimiterProcessor = new DelimiterProcessor();
        readonly PronounProcessor _pronounProcessor = new PronounProcessor();
        readonly StopwordProcessor _stopwordProcessor = new StopwordProcessor();
        readonly NonGeorgianWordsProcessor _nonGeorgianWordsProcessor = new NonGeorgianWordsProcessor();
        readonly DuplicateWordProcessor _duplicateWordProcessor = new DuplicateWordProcessor();
        readonly ReturnCarriageProcessor _returnCarriageProcessor = new ReturnCarriageProcessor();
        readonly NumericWordsProcessor _numericWordsProcessor = new NumericWordsProcessor();

        public Form1()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            var input = txtInput.Text;

            var returnCarriageProcessResult = _returnCarriageProcessor.Process(input);
            var nonGeorgianWordsProcessResult = _nonGeorgianWordsProcessor.Process(returnCarriageProcessResult.Output);
            var duplicateWordProcessResult = _duplicateWordProcessor.Process(nonGeorgianWordsProcessResult.Output);
            var stopWordProcessResult = _stopwordProcessor.Process(duplicateWordProcessResult.Output);
            var delimiterProcessResult = _delimiterProcessor.Process(stopWordProcessResult.Output);
            var prounoudProcessResult = _pronounProcessor.Process(delimiterProcessResult.Output);
            var numericWordsProcessResult = _numericWordsProcessor.Process(prounoudProcessResult.Output);


            MessageBox.Show(this,
                $@"ამოღებული არაქართული სიტყვების რაოდენობა : {nonGeorgianWordsProcessResult.RemovedEntries}" + "\n" +
                $@"ამოღებული დუპლიკატი სიტყვების რაოდენობა : {duplicateWordProcessResult.RemovedEntries}" + "\n" +
                $@"ამოღებული სტოპ სიტყვების რაოდენობა : {stopWordProcessResult.RemovedEntries}" + "\n" +
                $@"ამოღებული სასვენი ნიშნების რაოდენობა : {delimiterProcessResult.RemovedEntries}" + "\n" +
                $@"ამოღებული რიცხვითი სახელების რაოდენობა : {numericWordsProcessResult.RemovedEntries}" + "\n" +
                $@"ამოღებული ნაცვალსახელების რაოდენობა : {prounoudProcessResult.RemovedEntries}");

            txtOutput.Text = numericWordsProcessResult.Output;
        }
    }
}