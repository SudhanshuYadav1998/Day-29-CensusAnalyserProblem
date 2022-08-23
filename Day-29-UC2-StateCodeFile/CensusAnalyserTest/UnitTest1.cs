using Day_29_UC1_LoadDataFromCSV;
using Day_29_UC1_LoadDataFromCSV.DTO;
using static Day_29_UC1_LoadDataFromCSV.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\RFP\C_sharp\Day-29-UC1-LoadDataFromCSV\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\RFP\C_sharp\Day-29-UC1-LoadDataFromCSV\CensusAnalyserTest\CSVFiles\WrongIndianStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\RFP\C_sharp\Day-29-UC1-LoadDataFromCSV\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\RFP\C_sharp\Day-29-UC1-LoadDataFromCSV\CensusAnalyserTest\CSVFiles\WrongIndianStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\RFP\C_sharp\Day-29-UC1-LoadDataFromCSV\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\RFP\C_sharp\Day-29-UC1-LoadDataFromCSV\CensusAnalyserTest\CSVFiles\WrongIndianStateCodeFilePath.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\RFP\C_sharp\IndianStateCencusAnalyser\CencusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

    }
}
