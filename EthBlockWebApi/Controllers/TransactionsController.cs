using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Shared;
using EthBlockWebApi.Data;

namespace EthBlockWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly EthBlockWebApiContext _context;

    public TransactionsController(EthBlockWebApiContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetTransaction")]
    public IEnumerable<Transaction> Get()
        => _context.Transaction;


    //// GET: Transactions
    //public async Task<IActionResult> Index()
    //{
    //      return _context.Transaction != null ? 
    //                  View(await _context.Transaction.ToListAsync()) :
    //                  Problem("Entity set 'EthBlockWebApiContext.Transaction'  is null.");
    //}

    //// GET: Transactions/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null || _context.Transaction == null)
    //    {
    //        return NotFound();
    //    }

    //    var transaction = await _context.Transaction
    //        .FirstOrDefaultAsync(m => m.TransactionId == id);
    //    if (transaction == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(transaction);
    //}

    //// GET: Transactions/Create
    //public IActionResult Create()
    //{
    //    return View();
    //}

    //// POST: Transactions/Create
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("TransactionId,TransactionHash,TransactionIndex,Type,BlockHash,BlockNumber,From,To,Gas,GasPrice,MaxFeePerGas,MaxPriorityFeePerGas,Value,Input,Nonce,R,S,V")] Transaction transaction)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Add(transaction);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(transaction);
    //}

    //// GET: Transactions/Edit/5
    //public async Task<IActionResult> Edit(int? id)
    //{
    //    if (id == null || _context.Transaction == null)
    //    {
    //        return NotFound();
    //    }

    //    var transaction = await _context.Transaction.FindAsync(id);
    //    if (transaction == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(transaction);
    //}

    //// POST: Transactions/Edit/5
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, [Bind("TransactionId,TransactionHash,TransactionIndex,Type,BlockHash,BlockNumber,From,To,Gas,GasPrice,MaxFeePerGas,MaxPriorityFeePerGas,Value,Input,Nonce,R,S,V")] Transaction transaction)
    //{
    //    if (id != transaction.TransactionId)
    //    {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        try
    //        {
    //            _context.Update(transaction);
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!TransactionExists(transaction.TransactionId))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(transaction);
    //}

    //// GET: Transactions/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null || _context.Transaction == null)
    //    {
    //        return NotFound();
    //    }

    //    var transaction = await _context.Transaction
    //        .FirstOrDefaultAsync(m => m.TransactionId == id);
    //    if (transaction == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(transaction);
    //}

    //// POST: Transactions/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id)
    //{
    //    if (_context.Transaction == null)
    //    {
    //        return Problem("Entity set 'EthBlockWebApiContext.Transaction'  is null.");
    //    }
    //    var transaction = await _context.Transaction.FindAsync(id);
    //    if (transaction != null)
    //    {
    //        _context.Transaction.Remove(transaction);
    //    }
        
    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    //private bool TransactionExists(int id)
    //{
    //  return (_context.Transaction?.Any(e => e.TransactionId == id)).GetValueOrDefault();
    //}
}
