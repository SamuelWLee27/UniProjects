using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracTest1
{
    public class TestRecord
    {
        //declear fields
        private int _testYear;
        private string _location;
        private string _testType;
        private string _ageGroup;
        private int _totalTests;
        private int _totalFailed;

        /// <summary>
        /// gets test year
        /// </summary>
        public int TestYear
        {
            get { return _testYear; }
        }

        /// <summary>
        /// gets location then sets it if not empty
        /// </summary>
        public string Location
        {
            get { return _location; }
            set
            {
                //checks if empty
                if (value == "")
                {
                    //throws back exception
                    throw new Exception("location needs to be specified");
                }
                else
                {
                    //sets location to value
                    _location = value;
                }
            }
        }
        /// <summary>
        /// gets test type then sets it if not empty
        /// </summary>
        public string TestType
        {
            get { return _testType; }
            set
            {
                //checks if empty
                if (value == "")
                {
                    //throws back exception
                    throw new Exception("Test type needs to be specified");
                }
                else
                {
                    //sets test type to value
                    _testType = value;
                }
            }
        }
        /// <summary>
        /// gets age group then sets it if not empty
        /// </summary>
        public string AgeGroup
        {
            get { return _ageGroup; }
            set
            {
                //checks if empty
                if (value == "")
                {
                    //throws back exception
                    throw new Exception("Age group needs to be specified");
                }
                else
                {
                    //sets age group to value
                    _ageGroup = value;
                }
            }
        }
        /// <summary>
        /// gets total tests and checks if 0 or less then set a value for it
        /// </summary>
        public int TotalTests
        {
            get { return _totalTests; }
            set
            {
                //checks if less or equal to 0
                if (value <= 0)
                {
                    //throws back exception
                    throw new Exception("Total test needs to be greater then 0");
                }
                else
                {
                    //sets total test to value
                    _totalTests = value;
                }
            }
        }
        /// <summary>
        /// gets total failed and sets it to value if less then or
        /// equal to 0
        /// </summary>
        public int TotalFailed
        {
            get { return _totalFailed; }
            set
            {
                //checks if less or equal to 0
                if (value <= 0)
                {
                    //throws back exception
                    throw new Exception("Total test needs to be greater then 0");
                }
                else
                {
                    //sets total failed tests to value
                    _totalFailed = value;
                }
            }
        }
        /// <summary>
        /// gets total tests and total failed test and returns total tests passed
        /// </summary>
        public int TotalPassed
        {
            get { return TotalTests - TotalFailed;}
        }
        /// <summary>
        /// Initialises the feilds
        /// </summary>
        /// <param name="testYear">year of the test</param>
        /// <param name="location">location of the test</param>
        /// <param name="testType">type of test (full, restricted, learners)</param>
        /// <param name="ageGroup">age group of people taking the test</param>
        /// <param name="totalTests">Total number of test</param>
        /// <param name="totalFailed">Total tests failed</param>
        public TestRecord(int testYear, string location, string testType,
            string ageGroup, int totalTests, int totalFailed)
        {
            _testYear = testYear;
            Location = location;
            TestType = testType;
            AgeGroup = ageGroup;
            TotalTests = totalTests;
            TotalFailed = totalFailed;
        }
        /// <summary>
        /// calulate rate at which people fail the test
        /// </summary>
        /// <returns>fail rate</returns>
        public double CalcFailRate()
        {
            return (double)TotalFailed / TotalTests;
        }
        /// <summary>
        /// override tostring with neatly padded data
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TestYear.ToString().PadRight(8) + Location.ToString().PadRight(15)
                + TestType.ToString().PadRight(15) + AgeGroup.ToString().PadRight(15)
                + TotalTests.ToString("N0").PadRight(10) + TotalFailed.ToString("N0").PadRight(10)
                + TotalPassed.ToString("N0").PadRight(10) + CalcFailRate().ToString("n2") + "%";
        }
    }
}
